using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lubricants.Models;
using Fuela.DBContext;
using Microsoft.AspNetCore.Http;

namespace Lubricants.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext _context;
      
        public HomeController(ApplicationDBContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;

        }
        private readonly ILogger<HomeController> _logger;

       

        public IActionResult LoginUser(c_Users user)
        {
            if (user.strUserId == null || user.strPassword == null)
            {
                return Content("put user/pass");
            }
            var Username = user.strEmail;

            TokenProvider TokenProvider = new TokenProvider(_context);

            var userToken = TokenProvider.LoginUser(user.strUserId, user.strPassword);
            if (userToken == null)
            {

                return Content("Incorrect User Or Pass");

            }

            HttpContext.Session.SetString("JWToken", userToken);
            HttpContext.Session.SetString("User", Username);
            return Redirect("~/Administration/Dashboard");

        }
        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Home/Index");

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
