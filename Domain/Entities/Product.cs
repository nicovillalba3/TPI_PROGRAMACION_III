﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public string Name {  get; set; }

        public string Id { get; set; }

        public int Stock {  get; set; }

        public double Price { get; set; }
            
        public string Image { get; set; }

    }
}
