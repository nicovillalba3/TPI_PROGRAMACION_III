using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cart
    {
        public int Order { get; set; }
        public List<Product> ProductList { get; set; } = new List<Product>();
        public decimal TotalPrice { get; set; }

        public int AmountProducts { get; set; }

        public string TypePayment {  get; set; }

        

        public void AddProduct(Product product)
        {
            ProductList.Add(product);
            TotalPrice += product.Price;
            AmountProducts += 1;
        }

        public void RemoveProduct(Product product)
        {
            if (ProductList.Remove(product))
            {
                TotalPrice -= product.Price;
                AmountProducts -= 1;
            }
        }

        public void ClearCart()
        {
            ProductList.Clear();
            TotalPrice = 0;
            AmountProducts = 0;
        }
    }
}
