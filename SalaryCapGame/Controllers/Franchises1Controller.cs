using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalaryCapData;
using SalaryCapData.Models;
using SalaryCapGame.WebViewModels;

namespace SalaryCapGame.Controllers
{
    public class Franchises1Controller : Controller
    {
        private readonly IFranchise _franchise;
        private readonly ILeague _leagues;

        public Franchises1Controller( IFranchise franchise, ILeague leagues )
        {
            _franchise = franchise;
            _leagues = leagues;
        }

        // GET: Franchises1
        public IActionResult Index()
        {
            return View( _franchise.GetAll() );
        }

        // GET: Franchises1/Details/5
        public IActionResult Details( int id )
        {
            if (id == 0 )
            {
                return NotFound();
            }

            var franchise = _franchise.Get( id );
            if (franchise == null)
            {
                return NotFound();
            }

            return View(franchise);
        }

        // GET: Franchises1/Create
        public IActionResult Create( int ownerId )
        {
            ownerId = 4;
            var franchiseModel = new FranchiseModel
            {
                OwnerId = ownerId,
            };
            var leagues = _leagues.GetAll();
            var leagueListingResult = leagues.Select( result => new LeagueIndexListingModel
            {
                Id = result.LeagueId,
                Name = result.Name,
                Commissioner = result.Commissioner,
                LeagueInfo = result.Franchises.Count().ToString() + "/10"
            } );
            var franchiseLeagueModel = new FranchiseLeagueModel
            {
                FranchiseModel = franchiseModel,
                Leagues = leagueListingResult
            };
            return View( franchiseLeagueModel );
        }

        // POST: Franchises1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FranchiseId,Name,ImageUrl,DateCreated,DateModified")] Franchise franchise)
        {
            if (ModelState.IsValid)
            {
                _franchise.Add(franchise);
                return RedirectToAction(nameof(Index));
            }
            return View(franchise);
        }

        // GET: Franchises1/Edit/5
        public IActionResult Edit( int id )
        {
            if ( id == 0 )
            {
                return NotFound();
            }

            var franchise = _franchise.Get( id );
            if ( franchise == null )
            {
                return NotFound();
            }
            return View( franchise );
        }

        // POST: Franchises1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("FranchiseId,Name,ImageUrl,DateCreated,DateModified")] Franchise franchise)
        {
            if ( id != franchise.FranchiseId )
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _franchise.Update( franchise );
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FranchiseExists( franchise.FranchiseId ))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction( nameof( Index ));
            }
            return View( franchise );
        }

        //// GET: Franchises1/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var franchise = await _franchise.Franchises
        //        .SingleOrDefaultAsync(m => m.FranchiseId == id);
        //    if (franchise == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(franchise);
        //}

        //// POST: Franchises1/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var franchise = await _franchise.Franchises.SingleOrDefaultAsync(m => m.FranchiseId == id);
        //    _franchise.Franchises.Remove(franchise);
        //    await _franchise.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool FranchiseExists( int id )
        {
            return _franchise.Get( id ) == null;
        }
    }
}
