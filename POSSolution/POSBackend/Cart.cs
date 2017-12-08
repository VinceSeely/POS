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
    class Cart
    {
        
        private List<ItemQuantityPair> items;
        private Guid userID;
        private List<Coupon> coupons;
        private float total = 0;

        ///// <summary>
        ///// returns the index of the item in the cart or -1 if not found
        ///// </summary>
        ///// <param name="sku"></param>
        ///// <returns></returns>
        //private int lookFor(int sku)
        //{
        //    foreach (ItemQuantityPair subject in items)
        //    {
        //        if (subject.item.SKU() == sku)
        //            return items.IndexOf(subject);
        //    }

        //    return -1;
        //}

        /// <summary>
        /// Adds num of item to the cart
        /// </summary>
        /// <param name="item">item to be added to the cart</param>
        /// <param name="num">quantity of item to be added</param>
        public void addItem(Item item, int num)
        {
            //find the index of the item in the cart if available
            //int index = lookFor(item.SKU());
            int index = items.IndexOf(new ItemQuantityPair(item, 0));

            //if the one of the item is in the cart update the quantity
            if (index != -1)
                items[index].quantity += num;

            //otherwise add an instance of that item to the cart with the quantity
            else
            {
                ItemQuantityPair newPair = new ItemQuantityPair(item, num);
                items.Add(newPair);
            }

            runningTotal();
        }

        /// <summary>
        /// Removes num of the given item from the cart
        /// </summary>
        /// <param name="item">item to be removed</param>
        /// <param name="num">number of specified number to be removed</param>
        public void removeItem(Item item, int num)
        {
            //find the index of the item in the cart
            //int index = lookFor(sku);
            int index = items.IndexOf(new ItemQuantityPair(item, 0));

            //if user is removing all of the item remove it from the list
            if (num >= items[index].quantity)
                items.Remove(items[index]);
            
            //if user is not removing all of the item update the quantity
            else
                items[index].quantity -= num;

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
            foreach (ItemQuantityPair subject in items)
                total += (subject.item.Price() * subject.quantity);

            // Subtract the discounts from all coupons
            foreach (Coupon cou in coupons)
                total -= cou.Discount(total); // may or may not change param
        }
    }
}
