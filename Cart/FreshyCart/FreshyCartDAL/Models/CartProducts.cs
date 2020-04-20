using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FreshyCartDAL.Models
{
    public class CartProducts
    {
        
        [Key] // This is very important. 
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public short Quantity { get; set; }
        public string ProductImage { get; set; }
    }
}
