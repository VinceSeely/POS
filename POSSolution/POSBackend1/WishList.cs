using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBackend
{
    class WishList
    {
        private List<Item> itemList = new List<Item>();


        public List<Item> ItemList { get { return itemList; }}

        public void RemoveItem(Item removedItem)
        {
            itemList.Remove(removedItem);
        }

        public void AddItem(Item newitem)
        {
            itemList.Add(newitem);
        }
    }
}
