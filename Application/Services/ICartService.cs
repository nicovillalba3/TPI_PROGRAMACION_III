using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.DTOs;

namespace Application.Services
{
    public interface ICartService
    {
        void AddProductToCart(int orderId, Product product);
        void RemoveProductFromCart(int orderId, Product product);
        void DeleteCart(int orderId);
        void UpdateProductStock(int orderId, UpdateProductDto updateProductDto);
        decimal GetTotalPrice(int orderId);
        int GetTotalProducts(int orderId);
    }
}
