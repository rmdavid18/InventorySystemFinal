using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Renieldavid.inventoryManagementsystem.windows.DAL
{
   public  class DBContext :DbContext
    {
        public DBContext() : base("myConnectionString") 
        
        {
            Database.SetInitializer(new Renieldavid.inventoryManagementsystem.windows.DAL.DbtaInitializer ());
        }
        public DbSet < Models.User> Users { get; set; }
        public DbSet <Models.Product> products { get; set; }


    }
}
