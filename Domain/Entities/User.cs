using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public required string Id { get; set; }

        public required  string Email { get; set; }
        public  required string UserName { get; set; }

        public required string Password { get;  set; }

        public required UserRole Role { get; set; }
    }
}
