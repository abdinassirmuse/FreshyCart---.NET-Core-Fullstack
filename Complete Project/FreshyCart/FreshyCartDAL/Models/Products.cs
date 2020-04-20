using System;
using System.Collections.Generic;

namespace FreshyCartDAL.Models
{
    public partial class Products
    {
        public Products()
        {
            CartProduct = new HashSet<Cart>();
            CartProductImageNavigation = new HashSet<Cart>();
            CartProductNameNavigation = new HashSet<Cart>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ProductImage { get; set; }

        public ICollection<Cart> CartProduct { get; set; }
        public ICollection<Cart> CartProductImageNavigation { get; set; }
        public ICollection<Cart> CartProductNameNavigation { get; set; }
    }
}
