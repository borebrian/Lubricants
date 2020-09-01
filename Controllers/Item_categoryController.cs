using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fuela.DBContext;
using Lubricants.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Grpc.Core;

namespace Lubricants.Controllers
{
    public class Item_categoryController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public Item_categoryController(ApplicationDBContext context,IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Item_category
        public async Task<IActionResult> Index()
        {
            return View(await _context.Items_category.ToListAsync());
        }

       

        // GET: Item_category/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item_category = await _context.Items_category
                .FirstOrDefaultAsync(m => m.ID == id);
            if (item_category == null)
            {
                return NotFound();
            }

            return View(item_category);
        }

        // GET: Item_category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Item_category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Item_category model)
        {
            string fileName = System.IO.Path.GetFileName(model.Category_image.FileName);
            string filePath = "/Images/" + fileName;

            if (ModelState.IsValid)
            {
                if (model.Category_image !=null)
                {
                    string folder = "images/"+Guid.NewGuid().ToString() + model.Category_image.FileName;
                    folder += Guid.NewGuid().ToString() + model.Category_image.FileName;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    await model.Category_image.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

                    //model.SaveAs(Server.MapPath(filePath));

                    //var filename = Path.GetFileName(file.FileName);
                    //var path = Path.Combine(Server.MapPath("~/Uploads/Photo/"), filename);
                    //file.SaveAs(path);
                    //tyre.Url = filename;


                    Item_category itemC = new Item_category
                    {
                        Category_name = model.Category_name,
                        ImageURL = folder,
                     
                    };
                    _context.Add(itemC);
                    await _context.SaveChangesAsync();
                }

               
            }
            return RedirectToAction(nameof(Index));

        }


        // GET: Item_category/Edit/5
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

        // POST: Item_category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Category_title")] Item_category item_category)
        {
            if (id != item_category.ID)
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
                    if (!Item_categoryExists(item_category.ID))
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

        // GET: Item_category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item_category = await _context.Items_category
                .FirstOrDefaultAsync(m => m.ID == id);
            if (item_category == null)
            {
                return NotFound();
            }

            return View(item_category);
        }

        // POST: Item_category/Delete/5
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
            return _context.Items_category.Any(e => e.ID == id);
        }
    }
}
