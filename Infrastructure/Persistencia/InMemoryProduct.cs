using Domain.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistencia
{
    public class InMemoryProduct
    {
        private readonly ConcurrentDictionary<string, Product> _products = new ConcurrentDictionary<string, Product>();

        public Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return Task.FromResult(_products.Values.AsEnumerable());
        }

        public Task<Product> GetProductByIdAsync(string id)
        {
            _products.TryGetValue(id, out var product);
            return Task.FromResult(product);
        }

        public Task<bool> CreateProductAsync(Product product)
        {
            if (_products.Values.Any(p => p.Id == product.Id))
            {
                return Task.FromResult(false); // El producto ya existe
            }

            product.Id = Guid.NewGuid().ToString();
            _products[product.Id] = product;
            return Task.FromResult(true);
        }

        public Task<bool> UpdateProductAsync(Product product)
        {
            if (!_products.ContainsKey(product.Id))
            {
                return Task.FromResult(false); // El producto no existe
            }

            _products[product.Id] = product;
            return Task.FromResult(true);
        }

        public Task<bool> DeleteProductAsync(string id)
        {
            return Task.FromResult(_products.TryRemove(id, out _));
        }
    }
}
