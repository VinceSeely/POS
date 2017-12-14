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
        List<Item> itemList = new List<Item>();
        float totalPrice = 0;
        int orderNumber = 0;
        public Order(int number, List<Item> products, float price)
        {
            orderNumber++;
            itemList = products;
            totalPrice = price;
        }


        public Order getOrder(int orderNum)
        {
            return this;
        }

        public string toString()
        {
            string combinedString = "";
            int count = itemList.Count;
            
            for (int i = 0; i < count; i++)
            {
                combinedString += ((itemList[i]).ToString() + System.Environment.NewLine);
            }

            return combinedString;
        }
    }
}
