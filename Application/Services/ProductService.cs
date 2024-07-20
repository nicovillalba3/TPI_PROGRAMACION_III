using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private static List<Product> _products = new List<Product>();

        public Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return Task.FromResult(_products.AsEnumerable());
        }

        public Task<Product> GetProductByIdAsync(string id)
        {
            var product = _products.SingleOrDefault(p => p.Id == id);
            return Task.FromResult(product);
        }

        public Task<bool> CreateProductAsync(Product product)
        {
            if (_products.Any(p => p.Id == product.Id))
            {
                return Task.FromResult(false); // El producto ya existe
            }

            product.Id = Guid.NewGuid().ToString();
            _products.Add(product);
            return Task.FromResult(true);
        }

        public Task<bool> UpdateProductAsync(Product product)
        {
            var existingProduct = _products.SingleOrDefault(p => p.Id == product.Id);
            if (existingProduct == null)
            {
                return Task.FromResult(false); // El producto no existe
            }

            existingProduct.Name = product.Name;
            existingProduct.Stock = product.Stock;
            existingProduct.Price = product.Price;
            existingProduct.Image = product.Image;

            return Task.FromResult(true);
        }

        public Task<bool> DeleteProductAsync(string id)
        {
            var product = _products.SingleOrDefault(p => p.Id == id);
            if (product == null)
            {
                return Task.FromResult(false); // El producto no existe
            }

            _products.Remove(product);
            return Task.FromResult(true);
        }
    }
}
