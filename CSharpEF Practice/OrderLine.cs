using CSharpEF_Practice.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CSharpEF_Practice {
    public class OrderLine {

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

        public OrderLine() {

        }
    }
}
