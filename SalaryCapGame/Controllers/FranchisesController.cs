//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using SalaryCapData;
//using SalaryCapData.Models;
//using SalaryCapGame.WebViewModels;

//namespace SalaryCapGame.Controllers
//{
//    public class FranchisesController : Controller
//    {
//        private readonly IFranchise _context;

//        public FranchisesController( IFranchise context )
//        {
//            _context = context;
//        }

//        // GET: Franchises
//        public IActionResult Index()
//        {
//            //var gameDBContext = _context.Franchises.Include(f => f.League);
//            //return View(await gameDBContext.ToListAsync());
//            var franchiseModels = _context.GetAll();
//            var listingResult = franchiseModels.Select( result => new FranchiseIndexListingModel
//            {
//                Id = result.FranchiseId,
//                Name = result.Name,
//                Owner = result.Owner,
//                OwnerId = result.Owner.OwnerId,
//                League = result.League
//            } );

//            var model = new FranchiseIndexModel()
//            {
//                Franchises = listingResult
//            };

//            return ( View( model ) );
//        }

//        // GET: Franchises/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            return ( null );
//            //if (id == null)
//            //{
//            //    return NotFound();
//            //}

//            //var franchise = await _franchises.Owner.f .Franchises
//            //    .Include(f => f.League)
//            //    .SingleOrDefaultAsync(m => m.FranchiseId == id);
//            //if (franchise == null)
//            //{
//            //    return NotFound();
//            //}

//            //return View(franchise);
//        }

//        // GET: Franchises/Create
//        public IActionResult Create()
//        {
//            ViewData[ "LeagueId" ] = new SelectList( _franchises.League, "LeagueId", "Name" );
//            return View();
//        }

//        // POST: Franchises/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("FranchiseId,Name,LeagueId,DateCreated,DateModified")] IFranchise franchise)
//        {
//            if ( ModelState.IsValid )
//            {
//                _context.Add( franchise );
//                await _franchises.SaveChangesAsync();
//                return RedirectToAction( nameof( Index ) );
//            }
//            ViewData[ "LeagueId" ] = new SelectList( _context.Leagues, "LeagueId", "Name", franchise.LeagueId );
//            return View( franchise );

//        }

//        // GET: Franchises/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            //var franchise = await _context.Franchises.SingleOrDefaultAsync(m => m.FranchiseId == id);
//            //if (franchise == null)
//            //{
//            //    return NotFound();
//            //}
//            //ViewData["LeagueId"] = new SelectList(_context.Leagues, "LeagueId", "Name", franchise.LeagueId);
//            return View( null );
//        }

//        // POST: Franchises/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("FranchiseId,Name,LeagueId,DateCreated,DateModified")] Franchise franchise)
//        {
//            if (id != franchise.FranchiseId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    //_context.Update(franchise);
//                    //await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!FranchiseExists(franchise.FranchiseId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//          //  ViewData["LeagueId"] = new SelectList(_context.Leagues, "LeagueId", "Name", franchise.LeagueId);
//            return View(franchise);
//        }

//        // GET: Franchises/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var franchise = await _context.Franchises
//                .Include( f => f.League )
//                .SingleOrDefaultAsync( m => m.FranchiseId == id );
//            if ( franchise == null )
//            {
//                return NotFound();
//            }

//            return View(franchise);
//        }

//        // POST: Franchises/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var franchise = await _context.Franchises.SingleOrDefaultAsync(m => m.FranchiseId == id);
//            _context.Franchises.Remove(franchise);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool FranchiseExists(int id)
//        {
//            return _context.Franchises.Any(e => e.FranchiseId == id);
//        }
//    }
//}
