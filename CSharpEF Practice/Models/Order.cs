using PrsEfTutorialLibraryModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSharpEF_Practice.Models {
    public class Order {

        
        public int Id { get; set; }
        public string Description { get; set; }
        [StringLength(30)]
        [Required]
        public double Amount { get; set; }
        public int CustomerId { get; set; }
        public string Customer { get; set; }

        public Order() { }

    }
}
