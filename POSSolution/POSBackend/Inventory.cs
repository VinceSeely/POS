using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBackend
{
    class Inventory
    {
        private List<Item> inventory;
        private List<Coupon> couponList;

        /**
         * Searches for the item in the list 
         */
        private Item search(Item item)
        {
            return inventory.Find(item);
        }

        public void addItem(Item item)
        {
            
        }
    }
}
