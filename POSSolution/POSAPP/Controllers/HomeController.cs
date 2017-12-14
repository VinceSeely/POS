using Microsoft.AspNetCore.Mvc;
using POSBackend;
using System.Collections.Generic;
using System;

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

      public IActionResult Final()
      {
         return View();
      }

      public bool AddToCart(int sku)
      {
         return AccountManager.ACMInstance.AddToCart(sku);
      }

      public char Checkout()
      {
         
         var cart = AccountManager.ACMInstance.GetCart();
         AccountManager.ACMInstance.Checkout();
         if (cart.ContainsKey(Inventory.InventoryInstance.GetItem(8)))
         {
            return 'D';
         }
         
         return 'T';
      }

      private void MicDrop()
      {
         Response.Redirect("/Home/Final");
         
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
         loadData("Your Cart");
         ViewBag.Cart = AccountManager.ACMInstance.GetCart();
         return View();
      }

      public IActionResult Profile()
      {
         loadData("Profile");
         ViewBag.User = AccountManager.ACMInstance.GetCurrentUser();

         return View();
      }

      public IActionResult Orders()
      {
         loadData("Orders");
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
         loadData("Register");

         return View();
      }

      public bool SetUser(string username, string password)
      {
         return AccountManager.ACMInstance.Login(username, password);
      }

      public bool RegisterUser(string first, string last, string username, string password, string newPhoneNumber, string address, string state, string country, string city, string zipcode)
      {
         Address tempAddress = new Address
         {
            streetAddress = address ?? "",
            state = state ?? "",
            country = country ?? "",
            city = city ?? "",
            zipCode = zipcode != null ? int.Parse(zipcode) : 0
         };
         return AccountManager.ACMInstance.CreateAccount(username, first, last, password, newPhoneNumber, tempAddress);
      }

      public bool IsUsernameAvailable(string username)
      {
         return AccountManager.ACMInstance.IsUsernameAvailable(username);
      }

      public IActionResult InventoryPg()
      {
         loadData("Inventory");

         ViewBag.Inventory = Inventory.InventoryInstance.GetInventory();

         return View();
      }

      public void UpdateInventoryCount(int sku)
      {
         Inventory.InventoryInstance.AddExistingItem(sku);
      }

      private void loadData(string title, string username = "")
      {
         ViewData["Title"] = title;

         if (AccountManager.ACMInstance.GetCurrentUser() == null)
         {
            ViewData["loginLink"] = "/Home/LogIn";
            ViewData["LoginValue"] = "Login";
            ViewData["ProfileLink"] = "/Home/LogIn";
            ViewData["OrdersLink"] = "/Home/LogIn";
            ViewData["CartLink"] = "/Home/LogIn";
            ViewData["InventoryLink"] = "/Home/LogIn";
         }
         else
         {
            ViewData["loginLink"] = "/Home/LogIn";
            ViewData["LoginValue"] = "Logout";
            ViewData["ProfileLink"] = "/Home/Profile";
            ViewData["OrdersLink"] = "/Home/Orders";
            ViewData["CartLink"] = "/Home/Cart";
            ViewData["InventoryLink"] = "/Home/InventoryPg";
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
