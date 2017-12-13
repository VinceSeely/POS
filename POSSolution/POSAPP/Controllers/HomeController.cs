using Microsoft.AspNetCore.Mvc;
using POSBackend;

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
         ViewData["Message"] = $"{searchTerm}";
         var results = Inventory.InventoryInstance.search(searchTerm);
         ViewBag.SearchList = results;

         return View();
      }

      public IActionResult Cart()
      {
         ViewData["Message"] = "Your Current Cart";
         //.ACMInstance;
         //var temp1 = new AccountManager();
         //var temp = AccountManager.ACMInstance.Login("admin","bullshit");
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

      public IActionResult ItemPage(int sku)
      {
         var results = Inventory.InventoryInstance.search(sku.ToString());
         var item = results[0].Name;
         ViewBag.Item = results[0];
         ViewData["Title"] = item;

         return View();
      }

      public IActionResult Error()
      {
         return View();
      }

   }
}
