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
    public class Item_category1Controller : Controller
    {
        private readonly ApplicationDBContext _context;

        public Item_category1Controller(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Item_category1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Items_category.ToListAsync());
        }

        // GET: Item_category1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item_category = await _context.Items_category
                .FirstOrDefaultAsync(m => m.IDT == id);
            if (item_category == null)
            {
                return NotFound();
            }

            return View(item_category);
        }

        // GET: Item_category1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Item_category1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDT,Category_name,ImageURL")] Item_category item_category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item_category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item_category);
        }

        // GET: Item_category1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item_category = await _context.Items_category.FindAsync(id);
            if (item_category == null)
            {
                return NotFound();
            }
            return View(item_category);
        }

        // POST: Item_category1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDT,Category_name,ImageURL")] Item_category item_category)
        {
            if (id != item_category.IDT)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item_category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Item_categoryExists(item_category.IDT))
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
            return View(item_category);
        }

        // GET: Item_category1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item_category = await _context.Items_category
                .FirstOrDefaultAsync(m => m.IDT == id);
            if (item_category == null)
            {
                return NotFound();
            }

            return View(item_category);
        }

        // POST: Item_category1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item_category = await _context.Items_category.FindAsync(id);
            _context.Items_category.Remove(item_category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Item_categoryExists(int id)
        {
            return _context.Items_category.Any(e => e.IDT == id);
        }
    }
}
