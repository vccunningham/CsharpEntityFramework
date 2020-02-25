using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PrsEfTutorialLibraryModels {
    public class Customer {

        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        [Required]
        public string Name { get; set; }
        public double Sales { get; set; }
        public bool Active { get; set; }

        public override string ToString() => $"{Id}/{Name}/{Sales}/{Active}";
        


        public Customer() { }

    
        
    }
    
}
