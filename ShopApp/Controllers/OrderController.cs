using ShopApp.Models;
using ShopApp.Repositories;
using ShopApp.Utilities;
using ShopApp.Services;
using System.Threading.Tasks;

namespace ShopApp.Controllers
{
    public class OrderController
    {
        private ProductRepository _productRepository;

        public OrderController(ProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public async Task<bool> ProcessOrder(Order order)
        {
            if (_productRepository.GetQuantity(order.Product.ProductId) >= order.ProductQuantity)
            {
                decimal orderTotal = (decimal) (order.ProductQuantity * order.Product.Price);

                if (await CreditCardPaymentService.ChargePayment(order.Customer.CreditCardNumber, orderTotal))
                {
                    MailUtility.SendEmail(
                        new ConfirmationMessage
                        {
                            EmailAddress = MailUtility.shippingDepartmentEmail,
                            Message = $"Please ship the following order: {order.ProductQuantity} {order.Product.ProductId}\n CustomerId: {order.Customer.CustomerId}"
                        });

                    _productRepository.RemoveProduct(order.Product.ProductId, order.ProductQuantity);

                    return true;
                }
            }

            // throw error that order cannot be processed
            return false;
        }
    }
}
