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
    public class SkuQuantityPair
    {
        public SkuQuantityPair(int newSKU, int newQuantity)
        {
            SKU = newSKU;
            Quantity = newQuantity;
        }

        public int SKU { get; set; }

        public int Quantity { get; set; }

        public override bool Equals(object obj)
        {
            var realObject = obj as SkuQuantityPair;
            if (realObject == null)
                return false;
            return SKU.Equals(realObject.SKU );
        }
    }
}
