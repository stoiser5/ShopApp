using ShopApp.Models;
using System;

namespace ShopApp.Utilities
{
    public class MailUtility
    {
        public static string shippingDepartmentEmail = "shippingDepartment@shopApp.com";

        public static void SendEmail(ConfirmationMessage confirmationMessage)
        {
            Console.WriteLine($"{confirmationMessage.Message}\n sent to receiver {confirmationMessage.EmailAddress}");
            // Console.Read();
        }
    }
}
