using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;

namespace Application.Repositories
{
    public interface ICartRepository
    {
        void SaveCart(Cart cart);
        Cart GetCart(int orderId);
        void UpdateCart(Cart cart);
        void DeleteCart(int orderId);
        Cart GetCartById(int orderId);
        void CreateCart(Cart cart);
    }
}
