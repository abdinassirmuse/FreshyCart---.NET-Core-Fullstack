using System;
using System.Collections.Generic;

namespace FreshyCartWebAPI.Models
{
    public partial class Cart
    {
        public int ProductId { get; set; }
        public string EmailId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public short Quantity { get; set; }
    }
}
