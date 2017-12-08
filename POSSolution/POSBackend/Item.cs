namespace POSBackend
{
    public class Item
    {
        private string name;
        private int sku;
        private string type;
        private string department;
        private int count;
        private int OrderMoreLevel;
        private double AvgPerDay;
        private List<Retailer> retailerList = new List<>();


        public Item(string name, int sku, string department, string type, int orderMoreLevel)
        {
            this.name = name;
            this.sku = sku;
            this.department = department;
            this.type = type;
            this.orderMoreLevel = orderMoreLevel;
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

        public bool RemoveRetailer(Retailer retailer)
        {
            if (RetailerInList(retailer))
            {
                retailerList.Remove(retailer);
                return true;
            }

            return false;
        }



        public void UpdateCount(int newCount)
        {
            count = newcount;
        }

        public void UpdateOrderLevel(int newLevel)
        {
            orderMoreLevel = newLevel;
        }
    }
}