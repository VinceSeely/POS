namespace POSBackend
{
    internal class Coupon
    {
        private int sku;
        private int itemId;
        private int amountOff;

        public Coupon(int sku, int itemId, int amountOff)
        {
            this.sku = sku;
            this.itemId = itemId;
            this.amountOff = amountOff;
        }
    }
}