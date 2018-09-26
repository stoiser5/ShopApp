using ShopApp.Controllers;
using ShopApp.Models;
using ShopApp.Repositories;
using System.Threading.Tasks;

namespace ShopApp
{
    public class Program
    {
        public static async Task MainAsync()
        {
            Order newOrder = new Order
            {
                Product = new Product()
                {
                    ProductId = "Inventory300-Cat-Nip-Treats"
                },
                ProductQuantity = 5,
                Customer = new Customer()
                {
                    CustomerId = "11",
                    CreditCardNumber = "111111111111",
                    Email = "sigrid@gmail.com"
                }
            };

            OrderController orderController = new OrderController(new ProductRepository());

            await orderController.ProcessOrder(newOrder);
        }

        public static void Main(string[] args)
        {
            MainAsync().Wait();
        }
    }
}
