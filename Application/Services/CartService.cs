using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.DTOs;
using Application.Repositories;

namespace Application.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public void AddProductToCart(int orderId, Product product)
        {
            var cart = _cartRepository.GetCart(orderId) ?? new Cart { Order = orderId };
            cart.AddProduct(product);
            _cartRepository.SaveCart(cart);
        }

        public void RemoveProductFromCart(int orderId, Product product)
        {
            var cart = _cartRepository.GetCart(orderId);
            if (cart != null)
            {
                cart.RemoveProduct(product);
                _cartRepository.UpdateCart(cart);
            }
        }

        public void DeleteCart(int orderId)
        {
            _cartRepository.DeleteCart(orderId);
        }

        public void UpdateProductStock(int orderId, UpdateProductDto updateProductDto)
        {
            var cart = _cartRepository.GetCart(orderId);
            if (cart != null)
            {
                var product = cart.ProductList.FirstOrDefault(p => p.Id == updateProductDto.ProductId);
                if (product != null)
                {
                    int difference = updateProductDto.NewStock - product.Stock;
                    product.Stock = updateProductDto.NewStock;
                    cart.TotalPrice += difference * product.Price;
                    cart.AmountProducts += difference;
                    _cartRepository.UpdateCart(cart);
                }
            }
        }

        public decimal GetTotalPrice(int orderId)
        {
            var cart = _cartRepository.GetCart(orderId);
            return cart?.TotalPrice ?? 0;
        }

        public int GetTotalProducts(int orderId)
        {
            var cart = _cartRepository.GetCart(orderId);
            return cart?.AmountProducts ?? 0;
        }

        public string GetTypePayment(int orderId)
        {
            var cart = _cartRepository.GetCartById(orderId);
            if (cart == null)
            {
                throw new Exception("Cart not found");
            }
            return cart.TypePayment;
        }

        public void CreateCart(Cart cart)
        {
            _cartRepository.CreateCart(cart);
        }
    }
}
