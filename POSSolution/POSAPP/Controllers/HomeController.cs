using Microsoft.AspNetCore.Mvc;
using POSBackend;
using System.Collections.Generic;

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
         loadData("Orders", "LoggedIn");
         ViewData["Message"] = "Recent Orders:";

         return View();
      }

      public IActionResult ItemPage(int sku)
      {
         var results = Inventory.InventoryInstance.search(sku.ToString());
         var item = results[0].Name;
         ViewBag.Item = results[0];
         loadData(item);

         return View();
      }

      public IActionResult Register()
      {
         ViewData["Title"] = "Register";

         return View();
      }

      public bool SetUser(string username, string password)
      {
         return AccountManager.ACMInstance.Login(username, password);
      }

      private void loadData(string title, string loginVal = "", string username = "")
      {
         ViewData["Title"] = title;

         if (AccountManager.ACMInstance.GetCurrentUser() == null)
         {
            ViewData["loginLink"] = "/Home/LogIn";
            ViewData["LoginValue"] = "Login";
            ViewData["ProfileLink"] = "/Home/LogIn";
            ViewData["OrdersLink"] = "/Home/LogIn";
            ViewData["CartLink"] = "/Home/LogIn";
         }
         else
         {
            ViewData["loginLink"] = "/Home/LogIn";
            ViewData["LoginValue"] = "Logout";
            ViewData["ProfileLink"] = "/Home/Profile";
            ViewData["OrdersLink"] = "/Home/Orders";
            ViewData["CartLink"] = "/Home/Cart";
         }
         ViewData["RegisterLink"] = "/Home/Register";
         ViewData["HomeLink"] = "/Home";
      }

      public IActionResult LogIn()
      {
         if (AccountManager.ACMInstance.GetCurrentUser() != null)
            AccountManager.ACMInstance.LogOut();
         loadData("login");
         return View();
      }

      public IActionResult Error()
      {
         return View();
      }

   }
}
