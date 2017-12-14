using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBackend
{
   /// <summary>
   /// Manages the user's shopping cart
   /// </summary>
   public class Cart
   {

      private Dictionary<int, int> _items = new Dictionary<int, int>();
      private Guid userID;
      private List<Coupon> coupons =new List<Coupon>();
      private float total = 0;
      public Dictionary<int, int> Items { get { return _items; } }
      public float Total { get { return total; } }
      
      /// <summary>
      /// Adds num of item to the cart
      /// </summary>
      /// <param name="sku">sku to be added to the cart</param>
      /// <param name="num">quantity of item to be added</param>
      public bool addItem(int sku, int num)
      {
         //SkuQuantityPair item = new SkuQuantityPair(sku, num);

         //find the index of the item in the cart if available
         //int index = _Items.IndexOf(item);

         //if the one of the item is in the cart update the quantity
         if (!_items.ContainsKey(sku))
            _items[sku] = num;

         //otherwise add an instance of that item to the cart with the quantity
         else
         {
            _items[sku] += num;
         }

         runningTotal();
         return true;
      }

      /// <summary>
      /// Removes num of the given item from the cart
      /// </summary>
      /// <param name="sku">sku to be removed</param>
      /// <param name="num">number of specified number to be removed</param>
      public void removeItem(int sku, int num)
      {
         SkuQuantityPair item = new SkuQuantityPair(sku, num);

         //find the index of the item in the cart
         //int index = lookFor(sku);
         // int index = _Items.IndexOf(item);

         //if user is removing all of the item remove it from the list
         if (_items[sku] <= num)
            _items.Remove(sku);

         //if user is not removing all of the item update the quantity
         else
            _items[sku] = -num;

         runningTotal();
      }


      public void addCoupon()
      {
         runningTotal();
      }

      public void removeCoupon()
      {
         runningTotal();
      }

      /// <summary>
      /// Calculates the current total price of the cart
      /// </summary>
      private void runningTotal()
      {
         // Add the price of all items
         foreach (var subject in _items)
         {
            var item = Inventory.InventoryInstance.GetItem(subject.Key);
            total += (item.Price * subject.Value);
         }

         // Subtract the discounts from all coupons
         foreach (Coupon cou in coupons)
            total -= cou.Discount(total); // may or may not change param
      }
   }
}
