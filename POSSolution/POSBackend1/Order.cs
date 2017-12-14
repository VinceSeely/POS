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
      private List<int> itemSkus = new List<int>();
      private float totalPrice = 0;
      private int orderNumber = 0;
      public int OrderNubmer { get { return orderNumber; } }
      private static int nextOrderNumber = 0;
      public Order(List<int> products, float price)
      {
         orderNumber = nextOrderNumber;
         nextOrderNumber++;
         itemSkus = products;
         totalPrice = price;
      }


      public Order getOrder(int orderNum)
      {
         return this;
      }

      public string toString()
      {
         string combinedString = "";
         int count = itemSkus.Count;

         for (int i = 0; i < count; i++)
         {
            combinedString += ((itemSkus[i]).ToString() + System.Environment.NewLine);
         }

         return combinedString;
      }
   }
}
