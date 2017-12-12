using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBackend
{
    class Inventory
    {
        private Inventory _inventoryInstance;
        private List<Item> inventory;
        //private List<Coupon> couponList;
        public Inventory InventoryInstance { get
            {
                _inventoryInstance = _inventoryInstance ?? new Inventory();
                return _inventoryInstance;
            } }

        private Inventory()
        {

        }
        /**
         * Searches for the item in the list 
         */
        private Item search(Item item)
        {
            var temp  = inventory.Where(p => p.ShouldOrderMore ).OrderBy(x => x.Count).ToList();
            temp.Reverse();
            return inventory.FirstOrDefault(listItem => listItem.Equals(item));
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
