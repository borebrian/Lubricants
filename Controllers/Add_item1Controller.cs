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
    public class Add_item1Controller : Controller
    {
        private readonly ApplicationDBContext _context;

        public Add_item1Controller(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Add_item1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Add_item.ToListAsync());
        }

        // GET: Add_item1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var add_item = await _context.Add_item
                .FirstOrDefaultAsync(m => m.id == id);
            if (add_item == null)
            {
                return NotFound();
            }

            return View(add_item);
        }

        // GET: Add_item1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Add_item1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Category_id,Item_name,Item_price,Quantity,DateTime")] Add_item add_item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(add_item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(add_item);
        }

        // GET: Add_item1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var add_item = await _context.Add_item.FindAsync(id);
            if (add_item == null)
            {
                return NotFound();
            }
            return View(add_item);
        }

        // POST: Add_item1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Category_id,Item_name,Item_price,Quantity,DateTime")] Add_item add_item)
        {
            if (id != add_item.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(add_item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Add_itemExists(add_item.id))
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
            return View(add_item);
        }

        // GET: Add_item1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var add_item = await _context.Add_item
                .FirstOrDefaultAsync(m => m.id == id);
            if (add_item == null)
            {
                return NotFound();
            }

            return View(add_item);
        }

        // POST: Add_item1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var add_item = await _context.Add_item.FindAsync(id);
            _context.Add_item.Remove(add_item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Add_itemExists(int id)
        {
            return _context.Add_item.Any(e => e.id == id);
        }
    }
}
