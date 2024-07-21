using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        Product? Get(int id);
        List<Product> Get();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        bool DeleteProduct(int id);
    }
}
