using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public required string Name {  get; set; }

        public required int Id { get; set; }

        public required int Stock {  get; set; }

        public required double Price { get; set; }
            
        public required string Image { get; set; }

        public Product(string name, string id, int stock, double price, string image)
        {
            Name = name;

            Id = id;
            
            Stock = stock;

            Price = price;

            Image = image;

        }


    }
}
