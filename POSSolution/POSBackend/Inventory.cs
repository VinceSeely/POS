using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBackend
{
    class Inventory
    {
        private List<ItemQuantityPair> inventory;
        private List<Coupon> couponList;

        /**
         * Searches for the item in the list 
         */
        private Item search(Item item)
        {
            return inventory.
        }

        /**
         * Searches for an item in the inventory
         * if item is found it increments the count according to added item count
         * if item is not found it creates a new item in inventory and adds the correct number of items
         */
        public void addItem(Item item)
        {
            Item itemFound = search(item);

            if (itemFound != null)
                ;// update existing item count

            else
                inventory.Add(item);                
        }
    }
}
