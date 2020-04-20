using System;
using System.Collections.Generic;

namespace FreshyCartDAL.Models
{
    public partial class Cart
    {
        public int ProductId { get; set; }
        public string EmailId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public short Quantity { get; set; }

        public Users Email { get; set; }
        public Products Product { get; set; }
        public Products ProductImageNavigation { get; set; }
        public Products ProductNameNavigation { get; set; }
    }
}
