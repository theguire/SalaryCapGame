using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalaryCapData;
using SalaryCapData.Models;

namespace SalaryCapGame.Controllers
{
    public class Owners2Controller : Controller
    {
        private readonly IOwner _context;

        public Owners2Controller(IOwner context)
        {
            _context = context;
        }

        // GET: Owners2
        public IActionResult Index()
        {
            var owners = _context.GetAll();
            return View( owners.ToList() );
        }

        // GET: Owners2/Details/5
        public IActionResult Details( int id )
        {
            if (id == 0)
            {
                return NotFound();
            }

            var owner = _context.Get( id );
            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        // GET: Owners2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Owners2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("OwnerId,FirstName,LastName,Email,ImageUrl,DateCreated,DateModified")] Owner owner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(owner);
                return RedirectToAction(nameof(Index));
            }
            return View(owner);
        }

        // GET: Owners2/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var owner = _context.Get( id );
            if (owner == null)
            {
                return NotFound();
            }
            return View(owner);
        }

        // POST: Owners2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("OwnerId,FirstName,LastName,Email,ImageUrl,DateCreated,DateModified")] Owner owner)
        {
            if (id != owner.OwnerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update( owner );
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.OwnerExists(owner.OwnerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(owner);
        }

        // GET: Owners2/Delete/5
        //public IActionResult Delete(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var owner = _context.Get( id );
        //    if (owner == null)
        //    {
        //        return NotFound();
        //    }
            

        //    return View(owner);
        //}

        //// POST: Owners2/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var owner = await _context.Owners.SingleOrDefaultAsync(m => m.OwnerId == id);
        //    _context.Owners.Remove(owner);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

    }
}
