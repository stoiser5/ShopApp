using System.Threading.Tasks;

namespace ShopApp.Services
{
    public static class CreditCardPaymentService
    {
        private static readonly string creditCardApi = "https://www.creditcardcompany.com/payment";

        public static async Task<bool> ChargePayment(string creditCardNumber, decimal amount)
        {
            // normally this would make an http call to the API, e.g., 
            // HttpResponseMessage response = await new HttpClient().GetAsync(uri);

            return await Task.FromResult(true);
        }
    }
}
