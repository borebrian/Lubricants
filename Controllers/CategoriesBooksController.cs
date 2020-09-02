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
    public class CategoriesBooksController : Controller
    {
        private readonly ApplicationDBContext _context;

        public CategoriesBooksController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: CategoriesBooks
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriesBooks.ToListAsync());
        }
        //inabuild kweli?yea..sawa mean while..


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCatItems([Bind("ItemId,ItemName,CatId")] CatItems catItems)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catItems);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "CategoriesBooks");
            }
            return View(catItems);
        }
        //run sasa gani..CategoriesBooks
        // GET: CategoriesBooks/Details/5


        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriesBooks = await _context.CategoriesBooks
                .FirstOrDefaultAsync(m => m.id == id);
            if (categoriesBooks == null)
            {
                return NotFound();
            }
            BooksDetailsViewModel viewModel = await GetCartDetailsViewModelFromGroup(categoriesBooks);
            return View(viewModel);
            //  return View(categoriesBooks);
        }

        private async Task<BooksDetailsViewModel> GetCartDetailsViewModelFromGroup(CategoriesBooks croup)
        {
            BooksDetailsViewModel viewModel = new BooksDetailsViewModel();
            viewModel.CategoriesBooks = croup;


            var ll = croup.id.ToString();


            List<CatItems> contacts = await _context.catItems .Where(m => m.CatId == ll).ToListAsync();
            viewModel.catItems = contacts;
            return viewModel;
        }

        // GET: CategoriesBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriesBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,CatName")] CategoriesBooks categoriesBooks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriesBooks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriesBooks);
        }

        // GET: CategoriesBooks/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //tumesahau kuselect iyo data...so haiload kitu..wedo it from here..
            var categoriesBooks = await _context.CategoriesBooks.FindAsync(id);
            if (categoriesBooks == null)
            {
                return NotFound();
            }
            return View(categoriesBooks);
        }

        // POST: CategoriesBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id,CatName")] CategoriesBooks categoriesBooks)
        {
            if (id != categoriesBooks.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriesBooks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriesBooksExists(categoriesBooks.id))
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
            return View(categoriesBooks);
        }

        // GET: CategoriesBooks/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriesBooks = await _context.CategoriesBooks
                .FirstOrDefaultAsync(m => m.id == id);
            if (categoriesBooks == null)
            {
                return NotFound();
            }

            return View(categoriesBooks);
        }

        // POST: CategoriesBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var categoriesBooks = await _context.CategoriesBooks.FindAsync(id);
            _context.CategoriesBooks.Remove(categoriesBooks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriesBooksExists(string id)
        {
            return _context.CategoriesBooks.Any(e => e.id == id);
        }
    }
}
