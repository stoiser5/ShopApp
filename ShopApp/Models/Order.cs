namespace ShopApp.Models
{
    public class Order
    {
        public Product Product { get; set; }

        public int ProductQuantity { get; set; }

        public Customer Customer { get; set; }
    }
}
