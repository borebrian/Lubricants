using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fuela.DBContext;
using Lubricants.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lubricants.Controllers
{
    public class Administration : Controller
    {
        private readonly ApplicationDBContext _context;
        static Boolean search;

        public Administration(ApplicationDBContext context)
        {
            _context = context;
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [AllowAnonymous]
        public IActionResult Log_in()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            var combineList = _context.Add_item.ToList();
            ViewBag.itemlist = combineList;
            List<Add_item> ListOfItems = _context.Add_item.ToList();
            List<Item_category> categorys = _context.Items_category.ToList();
            List<JoinCategoryAndItem> joinList = new List<JoinCategoryAndItem>();
            var categoryCount = _context.Items_category.Count();
            var ItemCount= _context.Add_item.Sum(i => i.Quantity);
            ViewBag.categoryCount = categoryCount;
            ViewBag.Itemcount = ItemCount;
         
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

    }
}
