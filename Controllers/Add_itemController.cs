using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fuela.DBContext;
using Lubricants.Models;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis;

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
        
        public void ConfirmStockSubmit(int id, int Quantity,String Item_name)
        {
            var query = _context.Add_item.Where(x => x.id == id).Single();
            ViewBag.InitialQuantity = query.Quantity;
            ViewBag.CurrentQuantity = Quantity;
            ViewBag.price = Quantity;
            float price = query.Item_price;
            int sold = int.Parse(query.Quantity.ToString()) - Quantity;
            float cashMade = price * sold;
            ViewBag.ChashMade = cashMade;
            //ViewBag.EnteredQuantity = Item_name;
         


        }
        public void bindSubmitItems()
        {
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            //ViewBag.d = currentDate;
            List <Add_item> ListOfItems = _context.Add_item.ToList();
            List<Item_category> categorys = _context.Items_category.ToList();
            List<JoinCategoryAndItem> joinList = new List<JoinCategoryAndItem>();

            var results = (from pd in categorys
                           join od in ListOfItems on pd.IDT equals od.Category_id
                           where  od.DateTime != currentDate && od.Quantity>0
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

                ViewBag.JoinList = JoinListToViewbag;

            } 
        }
            public IActionResult SubmitStock()
        {
            bindSubmitItems();
            ViewBag.AllowPopup = "2";

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitStock(int id, int Quantity, [Optional] string newItem)
        {

            var query = _context.Add_item.Where(x => x.id == id).Single();
            ViewBag.InitialQuantity = query.Quantity;
            ViewBag.CurrentQuantity = Quantity;
            float price = query.Item_price;
            int sold = int.Parse(query.Quantity.ToString()) - Quantity;
            float cashMade = price * sold;
            ViewBag.ChashMade = cashMade;
            ViewBag.price = price;
            ViewBag.Item_name = query.Item_name;

            ViewBag.sold = sold;
            ViewBag.EnteredQuantity = Quantity;
           
            ViewBag.AllowPopup = "1";
            bindSubmitItems();


            //INSERTION CODE

            //int closing_stock = Quantity;
            ////var combineList = _context.Add_item.Where(x => x.id == id);
            //var allFields = await _context.Add_item.FindAsync(id);
            //int database_stock = allFields.Quantity;
            //int itemSold = database_stock - closing_stock;
            //int newQuantity = Quantity;

            //AddSession(itemSold.ToString(), itemSold.ToString());
            //var query = _context.Add_item.Where(x => x.id == id).Single();
            ////LETS UPDATE VALUES IN DATABASE
            //query.Quantity = newQuantity;
            //query.DateTime = DateTime.Now.ToString("yyyy-MM-dd");
            //_context.Update(query);
            //await _context.SaveChangesAsync();


            ////LETS CALCULATE CASH MADE

            //float price = query.Item_price;
            //float cashMade = price * itemSold;
            //Guid g = Guid.NewGuid();
            ////LETS ADD SUBMITTED STOCK TO THEIR RESPECTIVE TABLES
            //var submitted = new Submited_stock()
            //{
            //    item_id = id,
            //    DateTime = DateTime.Now.ToString(),
            //    item_sold = itemSold,
            //    Cash_made = cashMade,
            //    User_id = g.ToString()

            //};
            //_context.Add(submitted);
            //_context.SaveChanges();
            //ViewBag.StockUpdateStatus = query.Item_name + " has been submitted successfully! \n Initial stock: " + database_stock + "\n Item sold: " + itemSold + "\n New stock: " + Quantity;
            //bindSubmitItems();


            return View();
        }

        public void AddSession(string SessionName,string SessionData)
        {
            HttpContext.Session.SetString(SessionName, SessionData.ToString());
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
        public void BindCategoryName()
        {
            //string selectedValue = cateGory.Category_name;
            List<Item_category> CategoryList = new List<Models.Item_category>();
            CategoryList = (from items in _context.Items_category select items).ToList();
            //idList.Insert(0, new Rental_Owners { National_id=0,Full_names})
            CategoryList.Insert(0, new Item_category { IDT = 0, Category_name = "--Select Category--" });
            ViewBag.categoryList = CategoryList;
        }
        public IActionResult Create(Item_category cateGory, [Optional] string Value)
        {

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






            BindCategoryName();

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
                //return RedirectToAction(nameof(Index));
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








            BindCategoryName();

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
            var query = _context.Add_item.Where(x => x.id == id).Single();
            ViewBag.itemName = query.Item_name;
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



        public async Task<IActionResult> Change_price(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var add_item = await _context.Add_item.FindAsync(id);
            var allFields = await _context.Add_item.FindAsync(id);
            int initialQnty = allFields.Quantity;
            ViewBag.init = initialQnty;
            var query = _context.Add_item.Where(x => x.id == id).Single();
            ViewBag.itemName = query.Item_name;
            if (add_item == null)
            {
                return NotFound();
            }
            return View(add_item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Change_price(int id, [Bind("id,Category_id,Item_name,Item_price,Quantity,DateTime")] Add_item add_item)
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
                    float initialQnty = allFields.Item_price;
                    //int newAvailable = newUserQnty + initialQnty;
                    //add_item.Quantity = newAvailable;
                    //var BookFromDb = await _context.Add_item.FindAsync(id);
                    var query = _context.Add_item.Where(x => x.id == id).Single();
                    query.Item_price = add_item.Item_price;
                    _context.Update(query);
                    await _context.SaveChangesAsync();
                    ViewBag.InitialQuantity = initialQnty;
                    ViewBag.NewQuantity = add_item.Item_price;
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();

                }

            }
            return View(add_item);
        }





        // GET: Add_item/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //string selectedValue = cateGory.Category_name;
            List<Item_category> CategoryList = new List<Models.Item_category>();
            CategoryList = (from items in _context.Items_category select items).ToList();
            //idList.Insert(0, new Rental_Owners { National_id=0,Full_names})
            CategoryList.Insert(0, new Item_category { IDT = 0, Category_name = "--Select Category--" });
            ViewBag.categoryList = CategoryList;

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
                    if (!Add_itemExists(add_item.Category_id.ToString()))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Create));
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
