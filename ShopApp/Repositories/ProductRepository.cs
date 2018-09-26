using System.Collections.Generic;

namespace ShopApp.Repositories
{
    public class ProductRepository
    {
        // this would be populated from a database
        private IDictionary<string, int> _productInventory = new Dictionary<string, int>()
        {
            { "Inventory300-Cat-Nip-Treats", 500 },
            { "Inventory500-Fish-Food", 1000 },
            { "Inventory700-Dog-Biscuits", 700 }
        };

        public int GetQuantity(string productId)
        {
            if (_productInventory.ContainsKey(productId))
            {
                return _productInventory[productId];
            }

            return 0;
        }

        public void AddProduct(string productId, int quantity)
        {
            if (_productInventory.ContainsKey(productId))
            {
                _productInventory[productId] += quantity;
            }
            else
            {
                _productInventory[productId] = quantity;
            }
        }

        public void RemoveProduct(string productId, int quantity)
        {
            if (_productInventory.ContainsKey(productId))
            {
                _productInventory[productId] -= quantity;
            }
        }
    }
}
