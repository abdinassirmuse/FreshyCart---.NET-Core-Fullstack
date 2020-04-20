using System;
using System.Collections.Generic;

namespace FreshyCartDAL.Models
{
    public partial class Users
    {
        public Users()
        {
            Cart = new HashSet<Cart>();
        }

        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }

        public ICollection<Cart> Cart { get; set; }
    }
}
