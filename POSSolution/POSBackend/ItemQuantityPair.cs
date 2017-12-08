using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBackend
{
    /// <summary>
    /// Pairing of an item and the quantity of that item 
    /// </summary>
    public class ItemQuantityPair
    {
        public ItemQuantityPair(Item newItem, int newQuantity)
        {
            item = newItem;
            quantity = newQuantity;
        }

        public Item item { get; set; }

        public int quantity { get; set; }
    }
}
