using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renieldavid.inventoryManagementsystem.windows.DAL
{
    public class DbtaInitializer : System.Data.Entity.DropCreateDatabaseAlways<DBContext>
    {
        protected override void Seed(DBContext context)
        {
            {
                context.Users.Add(new Models.User()
                {
                    Id = Guid.Parse("4529d6fd-e488-4667-ac85-5e7dd88a7d57"),
                    Firstname = "RenielKalboMasamangtao",
                    Lastname = "David",
                    EmailAddress = "youjizz.com",
                    assignment =  Models.Enums.Assignment.Admin,
                    Password = "Yayay",


                });
                context.Users.Add(new Models.User()
                {
                    Id = Guid.Parse("d9df259a-021c-447a-bcd8-cf3dfc7aecd4"),
                    Firstname = "Reniel",
                    Lastname = "David",
                    EmailAddress = "youjizz.com",
                    assignment = Models.Enums.Assignment.Employee,
                    Password = "Yayay",



                });

                context.Users.Add(new Models.User()
                {
                    Id = Guid.Parse("6d3fe8e6-298a-4d0e-9cfe-7d926873e356"),
                    Firstname = "niel",
                    Lastname = "Mallari",
                    EmailAddress = "youjizz.com",
                    assignment = Models.Enums.Assignment.Admin,
                    Password = "Yayay",


                });
                context.Users.Add(new Models.User()
                {
                    Id = Guid.Parse("f29562f9-79a3-4841-9d50-69e3aa358dbd"),
                    Firstname = "romano",
                    Lastname = "cedric",
                    EmailAddress = "youjizz.com",
                    assignment = Models.Enums.Assignment.Employee,
                    Password = "Yayay",



                });
                context.Users.Add(new Models.User()
                {
                    Id = Guid.Parse("e3227aa4-a961-42a9-ae64-355b174c7105"),
                    Firstname = "wesly",
                    Lastname = "alipio",
                    EmailAddress = "youjizz.com",
                    assignment = Models.Enums.Assignment.Admin,
                    Password = "Yayay",



                });
            }

        }
    }
}
