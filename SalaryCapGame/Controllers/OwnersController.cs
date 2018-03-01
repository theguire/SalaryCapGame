using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalaryCapData;
using SalaryCapData.ConsumeJson.Models.Game;
using SalaryCapData.Interfaces;
using SalaryCapData.Models;
using SalaryCapGame.ViewModels;
using SalaryCapGame.ViewModels.Dashboard;
using SalaryCapGame.ViewModels.Player;
using static SalaryCapData.ConsumeJson.Models.Game.HitterPoints;

namespace SalaryCapGame.Controllers
{
    public class OwnersController : Controller
    {
        private readonly IOwner _owners;
        private readonly ILeague _leagues;
        private readonly IPlayer _players;

        public OwnersController( IOwner owners, ILeague leagues, IPlayer players )
        {
            _owners = owners;
            _leagues = leagues;
            _players = players;
        }

        public IActionResult List( int id )
        {

            var owner = _owners.Get( id );
            var model = new OwnerIndexListingModel
            {
                Id = owner.Id,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                ImageUrl = owner.ImageUrl,
                Franchises = owner.Franchises,
                Leagues = owner.Leagues
            };
            
            return View( model );
        }
        // GET: Owners
        public IActionResult OwnersList()
        {
           
            var owners = _owners.GetAll();
            var listingResult = owners.Select( o => new OwnerIndexListingModel
            {
                Id = o.Id,
                Email = o.Email,
                FirstName = o.FirstName,
                LastName = o.LastName,
                ImageUrl = o.ImageUrl,
                Franchises = o.Franchises,
                Leagues = o.Leagues
            }).ToList();
            var model = new OwnerIndexModel { Owners = listingResult };
            return View( model );
        }

        public PartialViewResult View( int id )
        {
            var owner = _owners.Get( id );

            _leagues.AssignFranchiseLeagues( owner.Franchises );
            var model = new FranchiseMenuModel
            {
                OwnerId = owner.Id,
                Franchises = owner.Franchises,
                Leagues = owner.Leagues
            };

            return PartialView( "~/Views/Partial/Franchise/_View.cshtml", model );
        }

        // GET: Owners/Details/5
        public IActionResult Details( int id )
        {
			if ( id == 0 )
            {
                return NotFound();
            }

            var owner = _owners.Get( id );
            if ( owner == null )
            {
                return NotFound();
            }

            OwnerIndexListingModel ownerModel = GetOwnerIndexListingModel( id, owner );
            List<PlayerIndexListingModel> playersModel = GetPlayersIndexListingModel( id );
			StatsIndexListModel statsIndexListModel = GetAllStats();

            var playerModel = new PlayerIndexModel { Players = playersModel };
            var dashboardModel = new DashboardViewModel
            {
                OwnerIndex = ownerModel,
                PlayerIndexModel = playerModel,
            };

            return View( "List", dashboardModel );
        }

		private StatsIndexListModel GetAllStats()
		{

			IEnumerable<HitterStats> hitterStats = _players.GetHitterStats();
			IEnumerable<PitcherStats> pitcherStats = _players.GetPitcherStats();

			StatsIndexListModel statsModel = new StatsIndexListModel
			{
				HitterStats = hitterStats,
				PicthterStats = pitcherStats
			};

			return ( statsModel );
		}

        private List<PlayerIndexListingModel> GetPlayersIndexListingModel( int id )
        {
            IEnumerable<Player> players = _players.GetAll();

            if ( players == null )
                return null;
            
            var results = players.Select( p => new PlayerIndexListingModel
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Position = p.Position,
                Team = p.Team,
                Value = p.InitialValue,
                HitterStats = p.HitterStats,
                PitcherStats = p.PictherStats,
				TotalPoints = GetTotalPoints( p )
            } ).ToList();

            return results;
        }

		private int GetTotalPoints( Player player )
		{
			if ( player.Position == "P" )
				return (GetTotalPitcherPoints( player.PictherStats ));
			else
				return (GetTotalHitterPoints( player.HitterStats ));
		}

		private int GetTotalPitcherPoints( PitcherStats pictherStats )
		{
			return 100;

		}

		private int GetTotalHitterPoints( HitterStats hitterStats )
		{
			int hitPoints = hitterStats.Hits * (int)HitterPointValues.Hit;
			int runPoints = hitterStats.Runs * (int)HitterPointValues.Run;
			int doublePoints = hitterStats.Doubles * (int)HitterPointValues.Double;
			int triplePoints = hitterStats.Doubles * (int)HitterPointValues.Triple;
			int homeRunPoints = hitterStats.Doubles * (int)HitterPointValues.HomeRun;
			int rbiPoints = hitterStats.Doubles * (int)HitterPointValues.RBI;
			int walkPoints = hitterStats.Doubles * (int)HitterPointValues.Walk;
			int stolenBasePoints = hitterStats.Doubles * (int)HitterPointValues.StolenBase;
			int strikeoutPoints = hitterStats.Doubles * (int)HitterPointValues.Strikeout;
			int sacrificePoints = hitterStats.Sacrifices; 

			return (hitPoints
					+ runPoints
					+ doublePoints
					+ triplePoints
					+ homeRunPoints
					+ rbiPoints
					+ walkPoints
					+ stolenBasePoints
					+ sacrificePoints
					+ strikeoutPoints);

		}
        private OwnerIndexListingModel GetOwnerIndexListingModel( int id, Owner owner )
        {
            var ownerModel = new OwnerIndexListingModel
            {
                Id = owner.Id,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                ImageUrl = owner.ImageUrl,
                Franchises = owner.Franchises,
                Leagues = owner.Leagues

            };

            return ownerModel;
        }


        // GET: Owners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Owners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( [Bind( "Id,FirstName,LastName,Email,ImageUrl,DateCreated,DateModified" )] Owner owner )
        {
            if ( ModelState.IsValid )
            {
                _owners.Add( owner );
                return RedirectToAction( nameof( OwnersList ) );
            }
            return View( owner );
        }

        // GET: Owners/Edit/5
        public IActionResult Edit( int id )
        {
            if ( id == 0 )
            {
                return NotFound();
            }

            var owner = _owners.Get( id );
            if ( owner == null )
            {
                return NotFound();
            }
            return View( owner );
        }

        // POST: Owners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( int id, [Bind( "Id,FirstName,LastName,Email,ImageUrl,DateCreated,DateModified" )] Owner owner )
        {
            if ( id != owner.Id )
            {
                return NotFound();
            }

            if ( ModelState.IsValid )
            {
                try
                {
                    _owners.Update( owner );
                }
                catch ( DbUpdateConcurrencyException )
                {
                    if ( !OwnerExists( owner.Id ) )
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction( nameof( OwnersList ) );
            }
            return View( owner );
        }

        //// GET: Owners/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var owner = await _context.Owners
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (owner == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(owner);
        //}

        //// POST: Owners/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var owner = await _context.Owners.SingleOrDefaultAsync(m => m.Id == id);
        //    _context.Owners.Remove(owner);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool OwnerExists(int id)
        {
            return _owners.Get( id ) != null;
        }
    }
}
