using Microsoft.AspNetCore.Mvc;
using POSBackend;

namespace POSAPP.Controllers
{
   public class HomeController : Controller
   {
      public IActionResult Index()
      {
         loadData("home");
         return View();
      }

      public IActionResult About()
      {
         ViewData["Message"] = "Your application description page.";

         return View();
      }

      public IActionResult Search(string searchTerm)
      {
         loadData($"Search Results For {searchTerm}");
         //ViewData["Message"] = $"{searchTerm}";
         var results = Inventory.InventoryInstance.search(searchTerm);
         ViewBag.SearchList = results;

         return View();
      }

      public IActionResult Cart()
      {
         loadData("Your Cart", "LoggedIn");
         //.ACMInstance;
         //var temp1 = new AccountManager();
         //var temp = AccountManager.ACMInstance.Login("admin","bullshit");
         return View();
      }

      public IActionResult Profile()
      {
         loadData("Profile", "LoggedIn");


         return View();
      }

      public IActionResult Orders()
      {
         loadData("Orders", "d");
         ViewData["Message"] = "Recent Orders:";

         return View();
      }

      public IActionResult ItemPage(int sku)
      {
         var results = Inventory.InventoryInstance.search(sku.ToString());
         var item = results[0].Name;
         ViewBag.Item = results[0];
         ViewData["Title"] = item;

         return View();
      }

      private void loadData(string title, string loginVal = "", string username = "")
      {
         ViewData["Title"] = title;

         if (loginVal == "")
         {
            ViewData["loginLink"] = "/Home/LogIn";
            ViewData["LoginValue"] = "Login";
            ViewData["ProfileLink"] = "/Home/LogIn";
            ViewData["OrdersLink"] = "/Home/LogIn";
            ViewData["CartLink"] = "/Home/LogIn";
         }
         else
         {
            ViewData["loginLink"] = "/Home/Logout";
            ViewData["LoginValue"] = "Logout";
            ViewData["ProfileLink"] = "/Home/Profile";
            ViewData["OrdersLink"] = "/Home/Orders";
            ViewData["CartLink"] = "/Home/Cart";
         }




      }

      public IActionResult LogIn()
      {
         loadData("login");
         return View();
      }

      public IActionResult Error()
      {
         return View();
      }

   }
}
