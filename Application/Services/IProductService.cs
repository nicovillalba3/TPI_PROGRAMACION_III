using Application.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IProductService
    {
        Product Get(int id);
        List<Product> GetAll();
        void AddProduct(ProductForAddRequest request);
        void UpdateProduct(ProductForUpdateRequest request);
        bool DeleteProduct(int id, int userId);
    }
}
