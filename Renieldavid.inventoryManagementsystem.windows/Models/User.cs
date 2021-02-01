using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Renieldavid.inventoryManagementsystem.windows.Models.Enums;

namespace Renieldavid.inventoryManagementsystem.windows.Models
{
 public class User
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string EmailAddress { get; set; }
        public Enums.Assignment assignment { get; set; }
        public string  Password { get; set; }

        


    }
}
