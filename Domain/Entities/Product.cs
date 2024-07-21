using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public required string Name {  get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  int Id { get; set; }

        public required int Stock {  get; set; }

        public required decimal Price { get; set; }
            
        public required string Image { get; set; }


        public void CreateProduct(List<Product> products, Product product, User user)
        {
            if (user.Role != UserRole.Admin)
            {
                throw new UnauthorizedAccessException("Sólo el administrador puede crear nuevos productos.");
            }

            products.Add(product);
        }

        public void EditProduct(List<Product> products, int productId, string name, int stock, double price, string image, User user)
        {
            if (user.Role != UserRole.Admin)
            {
                throw new UnauthorizedAccessException("Sólo el administrador puede modificar productos.");
            }

            var product = products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                product.Name = name;
                product.Image = image;
                product.Price = price;
                product.Stock = stock;
            }
        }

        public void DeleteProduct(List<Product> products, int productId, User user)
        {
            if (user.Role != UserRole.Admin)
            {
                throw new UnauthorizedAccessException("Sólo el administrador puede eliminar productos.");
            }

            var product = products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                products.Remove(product);
            }
        }

    }
}
