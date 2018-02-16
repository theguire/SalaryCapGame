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

        public OwnersController( IOwner owners, ILeague leagues )
        {
            _owners = owners;
            _leagues = leagues;
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

        // GET: Owners/Details/5
        public IActionResult Details( int id )
        {
            if ( id == 0 )
            {
                return NotFound();
            }

            var owner = _owners.Get( id );
            foreach ( Franchise f in owner.Franchises )
            {
                f.League = _leagues.Get( f.LeagueId );
            }

            //foreach ( League l in owner.Leagues )
            
            if ( owner == null )
            {
                return NotFound();
            }
            var result = new OwnerIndexListingModel
            {
                Id = owner.Id,
                Email = owner.Email,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                ImageUrl = owner.ImageUrl,
                Franchises = owner.Franchises,
                Leagues = owner.Leagues
            };

            return View( result );
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
