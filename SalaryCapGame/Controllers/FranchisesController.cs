using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalaryCapData;
using SalaryCapData.Interfaces;
using SalaryCapData.Models;
using SalaryCapGame.ViewModels;

namespace SalaryCapGame.Controllers
{
    public class FranchisesController : Controller
    {
        private readonly IFranchise _franchises;
        private readonly ILeague _leagues;

        public FranchisesController( IFranchise franchises, ILeague leagues )
        {
            _franchises = franchises;
            _leagues = leagues;
        }

        // GET: Franchises
        public IActionResult Index()
        {
            var franchises = _franchises.GetAll();
            var results = franchises.Select( f => new FranchiseIndexListingModel
            {
                Id = f.Id,
                ImageUrl = f.ImageUrl,
                LeagueId = f.LeagueId,
                Name = f.Name,
                OwnerId = f.OwnerId,
                NumberOfTrades = f.NumberOfTrades,
                Points = f.Points,
                Value = f.Value
            } ).OrderBy( r => r.Points );

            return View( franchises.ToList() );
        }

        // GET: Franchises/Details/5
        public IActionResult Details( int id )
        {
            if ( id == 0 )
            {
                return NotFound();
            }

            var franchise = _franchises.Get( id );

            if ( franchise == null )
            {
                return NotFound();
            }

            return View( franchise );
        }

        // GET: Franchises/Create
        public IActionResult Create( int id )
        {
            //ViewData[ "LeagueId" ] = new SelectList( _leagues.GetAll(), "Id", "Name" );
            ViewData[ "Leagues" ] = BuildLeaguesList();
            var editFranchiseModel = new EditFranchiseModel
            {
                OwnerId = id,
                ImageUrl = "",
                Name = "",
        };
            
            //            ViewData["OwnerId"] = new SelectList(_franchises.Owners, "Id", "Email");
            
            return View( editFranchiseModel );
        }

        // POST: Franchises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( [Bind( "Id,Name,ImageUrl,LeagueId,OwnerId,DateCreated,DateModified" )] EditFranchiseModel franchiseModel, int selectedLeagueId )
        {
            if ( ModelState.IsValid )
            {
                var franchise = new Franchise
                {
                    ImageUrl = franchiseModel.ImageUrl,
                    Name = franchiseModel.Name,
                    LeagueId = selectedLeagueId,
                    OwnerId = franchiseModel.OwnerId,
                    NumberOfTrades = 3,
                    Value = 50
                };
                _franchises.Add( franchise );
                return RedirectToAction( nameof( Index ) );
            }
            //ViewData[ "LeagueId" ] = new SelectList( _leagues.GetAll(), "Id", "Name", franchise.LeagueId );
            // ViewData["OwnerId"] = new SelectList(_franchises.Owners, "Id", "Email", franchise.OwnerId);
            return View( franchiseModel );
        }

        // GET: Franchises/Edit/5
        public IActionResult Edit( int id )
        {
            if ( id == 0 )
            {
                return NotFound();
            }

            var franchise = _franchises.Get( id );
            if ( franchise == null )
            {
                return NotFound();
            }
            ViewData[ "LeagueId" ] = new SelectList( _leagues.GetAll(), "Id", "Name", franchise.LeagueId );
            // ViewData["OwnerId"] = new SelectList(_franchises.Owners, "Id", "Email", franchise.OwnerId);
            return View( franchise );
        }

        // POST: Franchises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( int id, [Bind( "Id,Name,ImageUrl,LeagueId,OwnerId,DateCreated,DateModified" )] Franchise franchise )
        {
            if ( id != franchise.Id )
            {
                return NotFound();
            }

            if ( ModelState.IsValid )
            {
                try
                {
                    _franchises.Update( franchise );
                }
                catch ( DbUpdateConcurrencyException )
                {
                    if ( !FranchiseExists( franchise.Id ) )
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction( nameof( Index ) );
            }
            ViewData[ "LeagueId" ] = new SelectList( _leagues.GetAll(), "Id", "Name", franchise.LeagueId );
            // ViewData["OwnerId"] = new SelectList(_franchises.Owners, "Id", "Email", franchise.OwnerId);
            return View( franchise );
        }

        //// GET: Franchises/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var franchise = await _franchises.Franchises
        //        .Include(f => f.League)
        //        .Include(f => f.Owner)
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (franchise == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(franchise);
        //}

        //// POST: Franchises/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var franchise = await _franchises.Franchises.SingleOrDefaultAsync(m => m.Id == id);
        //    _franchises.Franchises.Remove(franchise);
        //    await _franchises.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        
        private void PopulateLegauesDropDownList( object selectedLeague = null )
        {
            var leagues = from l in _leagues.GetAll() orderby l.Name select l;
            var selectLeagues = leagues.Select( l => new LeagueListingModel
            {
                Id = l.Id,
                NumberOfFranchises = l.Franchises.Count(),
                MaxLeagueSize = 10,
                Commissioner = l.Commissioner,
                CommissionerId = l.CommissionerId,
                Name = l.Name + " " + l.Franchises.Count().ToString() + " / " + "10 " + l.Commissioner.FirstName + " " + l.Commissioner.LastName
            } ).ToList();
            ViewData["LeagueId"] = new SelectList( selectLeagues, "Id", "Name", selectedLeague );
        }

        private IEnumerable<LeagueListingModel> BuildLeaguesList( object selectedLeague = null )
        {
            var leagues = from l in _leagues.GetAll() orderby l.Name select l;
            var selectLeagues = leagues.Select( l => new LeagueListingModel
            {
                Id = l.Id,
                NumberOfFranchises = l.Franchises.Count(),
                MaxLeagueSize = 10,
                Commissioner = l.Commissioner,
                CommissionerId = l.CommissionerId,
                Name = l.Name
            } ).ToList();

            return ( selectLeagues );

        }


        private bool FranchiseExists( int id )
        {
            return _franchises.Any( id );
        }
    }
}
