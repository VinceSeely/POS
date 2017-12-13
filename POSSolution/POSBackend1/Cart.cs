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
        
        private List<SkuQuantityPair> _Items;
        private Guid userID;
        private List<Coupon> coupons;
        private float total = 0;

        /// <summary>
        /// Adds num of item to the cart
        /// </summary>
        /// <param name="sku">sku to be added to the cart</param>
        /// <param name="num">quantity of item to be added</param>
        public void addItem(int sku, int num)
        {
            SkuQuantityPair item = new SkuQuantityPair(sku, num);

            //find the index of the item in the cart if available
            int index = _Items.IndexOf(item);

            //if the one of the item is in the cart update the quantity
            if (index != -1)
                _Items[index].Quantity = num;

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
        /// <param name="sku">sku to be removed</param>
        /// <param name="num">number of specified number to be removed</param>
        public void removeItem(int sku, int num)
        {
            SkuQuantityPair item = new SkuQuantityPair(sku, num);

            //find the index of the item in the cart
            //int index = lookFor(sku);
            int index = _Items.IndexOf(item);

            //if user is removing all of the item remove it from the list
            if (num >= _Items[index].Quantity)
                _Items.RemoveAt(index);
            
            //if user is not removing all of the item update the quantity
            else
                _Items[index].Quantity = -num;

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
            {
                var item = Inventory.InventoryInstance.GetItem(subject.SKU);
                total += (item.Price * subject.Quantity);
            }

            // Subtract the discounts from all coupons
            foreach (Coupon cou in coupons)
                total -= cou.Discount(total); // may or may not change param
        }
    }
}
