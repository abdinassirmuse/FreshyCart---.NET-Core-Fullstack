using System;
using System.Collections.Generic;

namespace FreshyCartWebAPI.Models
{
    public partial class Products
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ProductImage { get; set; }
    }
}
