using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renieldavid.inventoryManagementsystem.windows.Models
{
     public class Product
    {
        public Guid  ProductId { get; set; }
        public string Productname { get; set; }
        public string Brand { get; set; }
        public decimal price { get; set; }
    }
}
