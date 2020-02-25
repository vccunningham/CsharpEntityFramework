using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSharpEF_Practice {
    public class Product {

        
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public List<OrderLine> Orderlines { get; set; }


        public Product() { }
    }
    
}
