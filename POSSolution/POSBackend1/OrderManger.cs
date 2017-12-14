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

      internal int AddOrder(Dictionary<int, int> items, float total)
      {
         var newOrder = new Order(items, total);
         Inventory.InventoryInstance.RemoveItems(items);
         orders.Add(newOrder);
         return newOrder.OrderNumber;
      }

      internal List<Order> GetOrders(List<int> orderNumbers)
      {
         return orders.Where(p => orderNumbers.Contains(p.OrderNumber)).ToList();
      }

      internal Dictionary<int, int> GetOrder(int orderNumber)
      {
         return orders.FirstOrDefault(p => p.OrderNumber == orderNumber).getOrder();
      }
   }
}