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


            var ownerModel = new OwnerIndexListingModel
            {
                Id = owner.Id,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                ImageUrl = owner.ImageUrl,
                Franchises = owner.Franchises,
                Leagues = owner.Leagues
            };


            var players = _players.GetAll();
            var results = players.Select( p => new PlayerIndexListingModel
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Position = p.Position,
                Team = p.Team,
                Value = p.InitialValue
            } ).ToList();

            var playerModel = new PlayerIndexModel { Players = results };
            var dashboardModel = new DashboardViewModel
            {
                OwnerIndex = ownerModel,
                PlayerIndexModel = playerModel
            };

            return View( "List", dashboardModel );
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
