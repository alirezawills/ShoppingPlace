using ShoppingPlace.Core.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingPlace.Core.Entities.Account
{
    public class User:BaseEntity<long>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public required byte[] Password { get; set; }
        public required byte[] SaltPassword { get; set; }
        
    }
}
