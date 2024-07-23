using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateProductDto
    {
        public int ProductId { get; set; }
        public int NewStock { get; set; }
    }
}

