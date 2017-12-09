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
        
        private List<Item> _Items;
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
            int index = _Items.IndexOf(item);

            //if the one of the item is in the cart update the quantity
            if (index != -1)
                _Items[index].Count = num;

            //otherwise add an instance of that item to the cart with the quantity
            else
            {
                _Items.Add(item);
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
            int index = _Items.IndexOf(item);

            //if user is removing all of the item remove it from the list
            if (num >= _Items[index].Count)
                _Items.RemoveAt(index);
            
            //if user is not removing all of the item update the quantity
            else
                _Items[index].Count = -num;

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
            foreach (var subject in _Items)
                total += (subject.Price * subject.Count);

            // Subtract the discounts from all coupons
            foreach (Coupon cou in coupons)
                total -= cou.Discount(total); // may or may not change param
        }
    }
}
