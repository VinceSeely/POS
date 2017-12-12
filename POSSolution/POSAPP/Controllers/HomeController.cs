using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using POS

namespace POSAPP.Controllers
{
   public class HomeController : Controller
   {
      public IActionResult Index()
      {
         return View();
      }

      public IActionResult About()
      {
         ViewData["Message"] = "Your application description page.";

         return View();
      }

      public IActionResult Search(string searchTerm)
      {
         ViewData["Message"] = $"Results for {searchTerm}";

         return View();
      }

      public IActionResult Cart()
      {
         ViewData["Message"] = "Your Current Cart";
         //AccountManger.ACMInstance;
         return View();
      }

      public IActionResult Profile()
      {
         ViewData["Message"] = "Username is here";

         return View();
      }

      public IActionResult Orders()
      {
         ViewData["Message"] = "Recent Orders:";

         return View();
      }

      public IActionResult Error()
      {
         return View();
      }
   }
}
