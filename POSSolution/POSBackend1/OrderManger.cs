using System;
using System.Collections.Generic;
using System.Linq;

namespace POSBackend
{
   internal class OrderManger
   {
      private static OrderManger instance;
      private List<Order> orders;

      public static OrderManger OrderMangerInstance
      {
         get
         {
            instance = instance ?? new OrderManger();
            return instance;
         }
      }
      private OrderManger()
      {
         orders = new List<Order>();
      }

      internal void AddOrder(Dictionary<int, int> items, float total)
      {
         var skus = items.Select(item => item.Key).ToList();
         var newOrder = new Order(skus, total);
         Inventory.InventoryInstance.RemoveItems(items);
         orders.Add(newOrder);
      }
   }
}