using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace POSBackend
{
   public class Order
   {
      private Dictionary<int, int> itemQuantities= new Dictionary<int, int>();
      private float totalPrice = 0;
      private int orderNumber = 0;
      public int OrderNumber { get { return orderNumber; } }
      private static int nextOrderNumber = 0;
      public Order(Dictionary<int, int> products, float price)
      {
         orderNumber = nextOrderNumber;
         nextOrderNumber++;
         itemQuantities = products;
         totalPrice = price;
      }


      public Dictionary<int,int> getOrder()
      {
         return itemQuantities;
      }

      public string toString()
      {
         string combinedString = "";
         int count = itemQuantities.Count;

         for (int i = 0; i < count; i++)
         {
            combinedString += ((itemQuantities[i]).ToString() + System.Environment.NewLine);
         }

         return combinedString;
      }
   }
}
