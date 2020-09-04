﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fuela.DBContext;
using Lubricants.Models;
using System.Runtime.InteropServices;

namespace Lubricants.Controllers
{
    public class Add_itemController : Controller
    {
        private readonly ApplicationDBContext _context;
       static  Boolean search;

        public Add_itemController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Add_item
        public IActionResult Index()
        {
           
            return View();

        }

        // GET: Add_item/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var add_item = await _context.Add_item
                .FirstOrDefaultAsync(m => m.Category_id.ToString() == id);
            if (add_item == null)
            {
                return NotFound();
            }

            return View(add_item);
        }

        // GET: Add_item/Create
        public IActionResult Create(Item_category cateGory, [Optional] string Value)
        {
            string selectedValue = cateGory.Category_name;
            List<Item_category> CategoryList = new List<Models.Item_category>();
            CategoryList = (from items in _context.Items_category select items).ToList();
            //idList.Insert(0, new Rental_Owners { National_id=0,Full_names})
            CategoryList.Insert(0, new Item_category { IDT = 0, Category_name = "--Select Category--" });
            ViewBag.categoryList = CategoryList;

            var combineList = _context.Add_item.ToList();
            ViewBag.itemlist = combineList;
            List<Add_item> ListOfItems = _context.Add_item.ToList();
            List<Item_category> categorys = _context.Items_category.ToList();
            List<JoinCategoryAndItem> joinList = new List<JoinCategoryAndItem>();

            var results = (from pd in categorys
                           join od in ListOfItems on pd.IDT equals od.Category_id
                           select new
                           {
                               pd.Category_name,
                               od.Item_price,
                               pd.ImageURL,
                               od.Item_name,
                               od.Quantity,
                               od.id,

                           }).ToList();

            foreach (var item in results)
            {
                JoinCategoryAndItem JoinObject = new JoinCategoryAndItem();
                JoinObject.Category_name = item.Category_name;
                JoinObject.Item_price = item.Item_price;
                JoinObject.ImageURL = item.ImageURL;
                JoinObject.Quantity = item.Quantity;
                JoinObject.Item_name = item.Item_name;
                JoinObject.id = item.id;
                joinList.Add(JoinObject);


                var JoinListToViewbag = joinList.ToList();
                ViewData["SearchStatus"] = search;
                if (Value==null)
                {
                    ViewBag.JoinList = JoinListToViewbag;

                }

                else
                {

                    //LETS COUNT THE RESULTS
                    int counts = joinLists(Value).Count();
                    if(counts>0){
                        ViewBag.JoinList = joinLists(Value);
                        ViewBag.ItemsCount = counts;
                        ViewBag.SearchValue = Value;

                    }
                    else
                    {
                        ViewBag.JoinList = null;
                        ViewBag.ItemsCount = 0;
                        ViewBag.SearchValue = Value;

                    }

                }
            }







            return View();
        }



        // POST: Add_item/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Category_id,Item_name,Item_price,Quantity,DateTime")] Add_item add_item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(add_item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //var combineList = _context.Add_item.Include("category").ToList();
            //ViewBag.itemlist = combineList;




            List<Add_item> ListOfItems = _context.Add_item.ToList();
            List<Item_category> categorys = _context.Items_category.ToList();
            List<JoinCategoryAndItem> joinList = new List<JoinCategoryAndItem>();

            var results = (from pd in categorys
                           join od in ListOfItems on pd.IDT equals od.Category_id
                           select new
                           {
                               pd.Category_name,
                               od.Item_price,
                               pd.ImageURL,
                               od.Item_name,
                               od.Quantity,
                               od.id,
                             
                           }).ToList();

            foreach (var item in results)
            {
                JoinCategoryAndItem JoinObject = new JoinCategoryAndItem();
                JoinObject.Category_name = item.Category_name;
                JoinObject.Item_price = item.Item_price;
                JoinObject.ImageURL = item.ImageURL;
                JoinObject.Quantity = item.Quantity;
                JoinObject.Item_name = item.Item_name;
                JoinObject.id = item.id;
                joinList.Add(JoinObject);

                var JoinListToViewbag = joinList.ToList();

                ViewBag.JoinList = JoinListToViewbag;
            }









            return View();
        }
        public List<JoinCategoryAndItem> joinLists(string Value)
        {
            List<Add_item> ListOfItems = _context.Add_item.ToList();
            List<Item_category> categorys = _context.Items_category.ToList();
            List<JoinCategoryAndItem> joinList = new List<JoinCategoryAndItem>();
            List<JoinCategoryAndItem> joinList1 = new List<JoinCategoryAndItem>();

            var results = (from pd in categorys
                           join od in ListOfItems on pd.IDT equals od.Category_id
                           select new
                           {
                               pd.Category_name,
                               od.Item_price,
                               pd.ImageURL,
                               od.Item_name,
                               od.Quantity,
                               od.id,

                           }).ToList();

            foreach (var item in results)
            {
                JoinCategoryAndItem JoinObject = new JoinCategoryAndItem();
                JoinObject.Category_name = item.Category_name;
                JoinObject.Item_price = item.Item_price;
                JoinObject.ImageURL = item.ImageURL;
                JoinObject.Quantity = item.Quantity;
                JoinObject.Item_name = item.Item_name;
                JoinObject.id = item.id;
                joinList.Add(JoinObject);
                var joinedToList = joinList.ToList();

                var searchResults1 = joinedToList.Where(data => data.Item_name.Contains(Value.ToLower()) || data.Item_name.Contains(Value.ToUpper()) ||data.Category_name.Contains(Value.ToUpper()));
                joinList1 = searchResults1.ToList();



            }


            return joinList1;





        }
        [BindProperty]
        public Add_item Add_item1 { get; set; }
        public async Task<IActionResult> Add_stock(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var add_item = await _context.Add_item.FindAsync(id);
            var allFields = await _context.Add_item.FindAsync(id);
            int initialQnty = allFields.Quantity;
            ViewBag.init = initialQnty;
            if (add_item == null)
            {
                return NotFound();
            }
            return View(add_item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add_stock(int id, [Bind("id,Category_id,Item_name,Item_price,Quantity,DateTime")] Add_item add_item)
        {
            if (id != add_item.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int newUserQnty = add_item.Quantity;
                    var allFields = await _context.Add_item.FindAsync(id);
                    int initialQnty = allFields.Quantity;
                    int newAvailable = newUserQnty + initialQnty;
                    add_item.Quantity = newAvailable;
                   
                    //var BookFromDb = await _context.Add_item.FindAsync(id);
                    var query = _context.Add_item.Where(x => x.id == id).Single();
                    query.Quantity = newAvailable;
                    _context.Update(query);
                    await _context.SaveChangesAsync();
                    ViewBag.InitialQuantity = initialQnty;
                    ViewBag.NewQuantity = newAvailable;
                }
                catch (DbUpdateConcurrencyException)
                {
                        return NotFound();
                   
                }
          
            }
            return View(add_item);
        }

        // GET: Add_item/Edit/5
        public async Task<IActionResult> Edit(string id)
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

        // POST: Add_item/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Category_id,Item_name,Item_price,Quantity,DateTime")] Add_item add_item)
        {
            if (id != add_item.Category_id.ToString())
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
                    if (!Add_itemExists(add_item.Category_id.ToString()))
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

        // GET: Add_item/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var add_item = await _context.Add_item
                .FirstOrDefaultAsync(m => m.id.ToString() == id);
            if (add_item == null)
            {
                return NotFound();
            }

            return View(add_item);
        }

        // POST: Add_item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var add_item = await _context.Add_item.FindAsync(id);
            _context.Add_item.Remove(add_item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Add_itemExists(string id)
        {
            return _context.Add_item.Any(e => e.Category_id.ToString() == id);
        }
    }
}
