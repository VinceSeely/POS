using System;
using System.Collections.Generic;
using System.IO;

namespace POSBackend
{
   /**
    * Entity class for object item
    */
   public class Item
   {
      private string name;
      private int sku;
      private string searchTerm;
      private string department;
      private double AvgPerDay;
      private List<Retailer> retailerList = new List<Retailer>();
      private int count;
      private DateTime addedDate;
      private int totalSold = 0;
      private string imageFile;
      private int imageWidth, imageHeight;

      public string Department { get { return department; } }
      public string Name { get { return name; } }
      public string SearchTerm { get { return searchTerm; } }
      public int Count { get { return count; } set { count += value; } }
      public float Price { get; set; }
      public bool ShouldOrderMore { get { return count < OrderMoreLevel; } }
      public int SKU { get { return sku; } }
      public int OrderMoreLevel { get; set; }
      public string ImageFile { get { return imageFile; } }
      public int ImageWidth { get { return imageWidth; } }
      public int ImageHeight { get { return imageHeight; } }

      public Item(int newSku)
      {
         sku = newSku;
      }

      public Item(string newName, int newSku, string newDepartment, string newType, int newOrderMoreLevel, float newPrice, int newCount, string newImagePath, int newImageWidth, int newImageHeight)
      {
         name = newName;
         sku = newSku;
         department = newDepartment;
         searchTerm = newType;
         OrderMoreLevel = newOrderMoreLevel;
         Price = newPrice;
         count = newCount;
         addedDate = DateTime.Now;
         Byte[] bytes = File.ReadAllBytes(newImagePath);
         string image = Convert.ToBase64String(bytes);
         imageFile = image;
         imageWidth = newImageWidth;
         imageHeight = newImageHeight;
      }


      public bool AddRetailer(Retailer newRetailer)
      {
         int id = newRetailer.ID();

         if (!RetailerInList(id))
         {
            retailerList.Add(newRetailer);
            return false;
         }

         return true;
      }

      private bool RetailerInList(int id)
      {
         foreach (Retailer element in retailerList)
         {
            if (element.ID() == id)
               return true;
         }

         return false;
      }

      public bool RemoveRetailer(Retailer retailer)
      {
         if (RetailerInList(retailer.ID()))
         {
            retailerList.Remove(retailer);
            return true;
         }

         return false;
      }



      //public void UpdateCount(int newCount)
      //{
      //    count += newCount;
      //}

      //public void UpdateOrderLevel(int newLevel)
      //{
      //    orderMoreLevel = newLevel;
      //}

      public override bool Equals(object obj)
      {
         var realObj = obj as Item;
         if (realObj == null)
            return false;
         return sku.Equals(realObj.sku);
      }
   }
}