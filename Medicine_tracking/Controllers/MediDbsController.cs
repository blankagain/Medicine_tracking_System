using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Medicine_tracking.Context;
using Medicine_tracking.Models;

namespace Medicine_tracking
{
    public class MediDbsController : Controller
    {
        private readonly MediContext _context;

        public MediDbsController(MediContext context)
        {
            _context = context;
        }

        // GET: MediDbs
        public async Task<IActionResult> Index()
        {
            return View(await _context.MediDbs.ToListAsync());
        }

        // GET: MediDbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediDb = await _context.MediDbs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mediDb == null)
            {
                return NotFound();
            }

            return View(mediDb);
        }

        // GET: MediDbs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MediDbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Brand,Quantity,Price,ExpiryDate,Notes")] MediDb mediDb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mediDb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mediDb);
        }

        // GET: MediDbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediDb = await _context.MediDbs.FindAsync(id);
            if (mediDb == null)
            {
                return NotFound();
            }
            return View(mediDb);
        }

        // POST: MediDbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Brand,Quantity,Price,ExpiryDate,Notes")] MediDb mediDb)
        {
            if (id != mediDb.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mediDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediDbExists(mediDb.Id))
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
            return View(mediDb);
        }

        // GET: MediDbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediDb = await _context.MediDbs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mediDb == null)
            {
                return NotFound();
            }

            return View(mediDb);
        }

        // POST: MediDbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mediDb = await _context.MediDbs.FindAsync(id);
            _context.MediDbs.Remove(mediDb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MediDbExists(int id)
        {
            return _context.MediDbs.Any(e => e.Id == id);
        }
    }
}
