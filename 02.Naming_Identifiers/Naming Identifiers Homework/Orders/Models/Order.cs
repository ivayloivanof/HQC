namespace Orders
{
    public class Order
    {
        public int ID { get; set; }

        public int product_id { get; set; }

        public int quant { get; set; }

        public decimal Discount { get; set; }
    }
}
