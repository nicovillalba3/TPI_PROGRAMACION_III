using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Admin
    {
        public required string Dni { get; set; }
    }

    // Metodo para manejar productos
    public void CreateProduct(List<Product> products, Product product)
    {
        products.Add(product);
    }

    public void EditProduct(List<Product> products, int productId, string name, int stock, double price, string image)
    {
        var product = products.FirstOrDefault(p => p.Id == productId);
        if (product != null)
        {
            product.Name = name;
            product.Image = image;
            product.Price = price;
            product.Stock = stock;
        }
    }

    public void DeleteProduct(List<Product> products, int productId)
    {
        var product = products.FirstOrDefault(p => p.Id == productId);
        if (product != null)
        {
            products.Remove(product);
        }
    }
}
