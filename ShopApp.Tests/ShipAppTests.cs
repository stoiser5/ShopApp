using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopApp.Controllers;
using ShopApp.Models;
using ShopApp.Repositories;
using ShopApp.Services;
using System.Threading.Tasks;

namespace ShipAppTests
{
    [TestClass]
    public class ShipAppTests
    {
        // these methods should be moved into several files
        [TestMethod]
        public async Task OrderWithValidProductQuantity()
        {
            // Arrange
            Order newOrder = new Order
            {
                Product = new Product()
                {
                    ProductId = "Sheba sticks"
                },
                ProductQuantity = 5,
                Customer = new Customer()
                {
                    CustomerId = "11",
                    CreditCardNumber = "111111111111",
                    Email = "sigrid@gmail.com"
                }
            };

            ProductRepository productRepository = new ProductRepository();
            productRepository.AddProduct("Sheba sticks", 5);
            OrderController orderController = new OrderController(productRepository);

            // Act
            bool orderResult = await orderController.ProcessOrder(newOrder);

            // Assert
            Assert.IsTrue(orderResult);
        }

        [TestMethod]
        public async Task OrderWithInvalidValidProductQuantity()
        {
            // Arrange
            Order newOrder = new Order
            {
                Product = new Product()
                {
                    ProductId = "Sheba sticks"
                },
                ProductQuantity = 5,
                Customer = new Customer()
                {
                    CustomerId = "11",
                    CreditCardNumber = "111111111111",
                    Email = "sigrid@gmail.com"
                }
            };

            ProductRepository productRepository = new ProductRepository();
            productRepository.AddProduct("Sheba sticks", 2);
            OrderController orderController = new OrderController(productRepository);

            // Act
            bool orderResult = await orderController.ProcessOrder(newOrder);

            // Assert
            Assert.IsFalse(orderResult);
        }

        [TestMethod]
        public void GetProductQuantity()
        {
            // Arrange
            ProductRepository productRepository = new ProductRepository();

            // Act
            int quantity = productRepository.GetQuantity("Inventory500-Fish-Food");

            // Assert
            Assert.AreEqual(1000, quantity);
        }

        [TestMethod]
        public void ProductRepositoryRemoveProduct()
        {
            // Arrange
            ProductRepository productRepository = new ProductRepository();

            // Act
            productRepository.RemoveProduct("Inventory500-Fish-Food", 500);

            // Assert
            Assert.AreEqual(500, productRepository.GetQuantity("Inventory500-Fish-Food"));
        }

        [TestMethod]
        public async Task CreditCardPaymentServiceChargePayment()
        {
            // Arrange
            string creditCardNumber = "555555555";
            decimal paymentAmount = 500;

            // Act
            bool result = await CreditCardPaymentService.ChargePayment(creditCardNumber, paymentAmount);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
