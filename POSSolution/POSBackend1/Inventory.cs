using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBackend
{
   public class Inventory
   {
      private static Inventory _inventoryInstance;
      private List<Item> inventory;
      private List<Coupon> couponList;
      public static Inventory InventoryInstance
      {
         get
         {
            _inventoryInstance = _inventoryInstance ?? new Inventory();
            return _inventoryInstance;
         }
      }

      private Inventory()
      {
         var dir = Directory.GetCurrentDirectory();
         var itemLines = File.ReadLines($"{dir}\\Items.csv");//.Split(';');//.Select(a => a.Split(';'));
         inventory = (from line in itemLines
                      let item = line.Split(',')
                      select new Item(item[0], int.Parse(item[1]), item[3], item[4], int.Parse(item[5]), float.Parse(item[2]), int.Parse(item[6]), $"{Directory.GetCurrentDirectory()}\\wwwroot\\images\\{item[0]}.jpg", int.Parse(item[7]), int.Parse(item[8]))).ToList();
      }
      /**
       * Searches for the item in the list 
       */
      public List<Item> search(string searchTerm)
      {
         if (searchTerm == null)
            return Inventory.InventoryInstance.inventory;
         var temp = inventory.Where(p => !p.ShouldOrderMore).OrderBy(x => x.Count).ToList();
         temp.Reverse();
         var items = inventory.Where(p => p.Name.ToLower().Contains(searchTerm.ToLower()) || p.SearchTerm.ToLower().Contains(searchTerm.ToLower()) || searchTerm.ToLower().Contains(p.SearchTerm.ToLower()) || searchTerm.ToLower().Contains(p.Name.ToLower()) || p.SKU.ToString().StartsWith(searchTerm) || p.Department.ToLower().Contains(searchTerm.ToLower())).ToList();
         return items;
      }

      /**
       * Searches for an item in the inventory
       * if item is found it increments the count according to added item count
       * if item is not found it creates a new item in inventory and adds the correct number of items
       */
      public void addItem(Item item)
      {
         Item itemFound = inventory.FirstOrDefault(p => p.Equals(item)) ;

         if (itemFound != null)
            ;// update existing item count

         else
            inventory.Add(item);
      }

        public Item GetItem(int SKU)
        {
            return inventory.FirstOrDefault(p => p.SKU == SKU);
        }
    }
}
