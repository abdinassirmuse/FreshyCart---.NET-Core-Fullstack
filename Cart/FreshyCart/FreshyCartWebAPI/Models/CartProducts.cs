using System;
using System.Collections.Generic;
using System.Text;

namespace FreshyCartWebAPI.Models
{
    public class CartProducts
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public short Quantity { get; set; }
        public string ProductImage { get; set; }
    }
}
