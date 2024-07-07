using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cart
    {
        public Product[] ProductList { get; set; }
        public double TotalPrice { get; set; }

        public int AmountProducts { get; set; }

        public string TypePayment {  get; set; }

        public int Order {  get; set; }


    }
}
