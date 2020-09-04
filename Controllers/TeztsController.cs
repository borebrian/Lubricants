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
    public class TeztsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public TeztsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Tezts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tezt.ToListAsync());
        }

        // GET: Tezts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tezt = await _context.Tezt
                .FirstOrDefaultAsync(m => m.IDT == id);
            if (tezt == null)
            {
                return NotFound();
            }

            return View(tezt);
        }

        // GET: Tezts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tezts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDT,name")] Tezt tezt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tezt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tezt);
        }

        // GET: Tezts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tezt = await _context.Tezt.FindAsync(id);
            if (tezt == null)
            {
                return NotFound();
            }
            return View(tezt);
        }

        // POST: Tezts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDT,name")] Tezt tezt)
        {
            if (id != tezt.IDT)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tezt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeztExists(tezt.IDT))
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
            return View(tezt);
        }

        // GET: Tezts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tezt = await _context.Tezt
                .FirstOrDefaultAsync(m => m.IDT == id);
            if (tezt == null)
            {
                return NotFound();
            }

            return View(tezt);
        }

        // POST: Tezts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tezt = await _context.Tezt.FindAsync(id);
            _context.Tezt.Remove(tezt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeztExists(int id)
        {
            return _context.Tezt.Any(e => e.IDT == id);
        }
    }
}
