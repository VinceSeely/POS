using System.Collections.Generic;

namespace POSBackend
{
    /**
     * Entity class for object item
     */
    public class Item
    {
        private string name;
        private int sku;
        private string type;
        private string department;
        private float price;
        private int orderMoreLevel;
        private double AvgPerDay;
        private List<Retailer> retailerList = new List<Retailer>();


        public Item(string name, int sku, string department, string type, int orderMoreLevel, float price)
        {
            this.name = name;
            this.sku = sku;
            this.department = department;
            this.type = type;
            this.orderMoreLevel = orderMoreLevel;
            this.price = price;

        }

        public float Price()
        {
            return price;
        }

        public int SKU()
        {
            return sku;
        }

        public bool AddRetailer(Retailer newRetailer)
        {
            int id = newRetailer.ID();

            if (!RetailerInList(id))
            {
                retailerList.Add(newRetailer);
                return false;
            }

            return true;
        }

        private bool RetailerInList(int id)
        {
            foreach(Retailer element in retailerList)
            {
                if (element.ID() == id)
                    return true;
            }

            return false;
        }

        public bool RemoveRetailer(Retailer retailer)
        {
            if (RetailerInList(retailer.ID()))
            {
                retailerList.Remove(retailer);
                return true;
            }

            return false;
        }



        public void UpdateCount(int newCount)
        {
            count = newCount;
        }

        public void UpdateOrderLevel(int newLevel)
        {
            orderMoreLevel = newLevel;
        }

        public override bool Equals(object obj)
        {
            var realObj = obj as Item;
            if (realObj == null)
                return false;
            return sku.Equals(realObj.sku);
        }
    }
}