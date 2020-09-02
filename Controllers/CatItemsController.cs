using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fuela.DBContext;
using Lubricants.Models;

namespace Lubricants.Controllers
{
    public class CatItemsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public CatItemsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: CatItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.catItems.ToListAsync());
        }

        // GET: CatItems/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catItems = await _context.catItems
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (catItems == null)
            {
                return NotFound();
            }

            return View(catItems);
        }

        // GET: CatItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,ItemName,CatId")] CatItems catItems)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catItems);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catItems);
        }

        // GET: CatItems/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catItems = await _context.catItems.FindAsync(id);
            if (catItems == null)
            {
                return NotFound();
            }
            return View(catItems);
        }

        // POST: CatItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ItemId,ItemName,CatId")] CatItems catItems)
        {
            if (id != catItems.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catItems);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatItemsExists(catItems.ItemId))
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
            return View(catItems);
        }

        // GET: CatItems/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catItems = await _context.catItems
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (catItems == null)
            {
                return NotFound();
            }

            return View(catItems);
        }

        // POST: CatItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var catItems = await _context.catItems.FindAsync(id);
            _context.catItems.Remove(catItems);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatItemsExists(string id)
        {
            return _context.catItems.Any(e => e.ItemId == id);
        }
    }
}
