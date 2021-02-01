using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renieldavid.inventoryManagementsystem.windows.Models;
using Renieldavid.inventoryManagementsystem.windows.DAL;

using Renieldavid.inventoryManagementsystem.windows.Helpers;

namespace Renieldavid.inventoryManagementsystem.windows.BLL
{
  public static  class UserBLL
    {
        private static DAL.DBContext db = new DAL.DBContext();

        public static Paged<Models.User> Search(int pageIndex = 1, int pageSize = 5, string sortBy = "lastname", string sortOrder = "asc", string keyword = "")
        {
            IQueryable<Models.User> allUsers = (IQueryable<Models.User>)db.Users;
            Paged<Models.User> Users = new Paged<Models.User>();

            if (!string.IsNullOrEmpty(keyword))
            {
                allUsers = allUsers.Where(e => e.Firstname.Contains(keyword) || e.Lastname.Contains(keyword));
            }

            var queryCount = allUsers.Count();
            var skip = pageSize * (pageIndex - 1);

            long pageCount = (long)Math.Ceiling((decimal)(queryCount / pageSize));

            if (sortBy.ToLower() == "firstname" && sortOrder.ToLower() == "asc")
            {
                Users.Items = allUsers.OrderBy(e => e.Firstname).Skip(skip).Take(pageSize).ToList();
            }
            else if (sortBy.ToLower() == "firstname" && sortOrder.ToLower() == "desc")
            {
                Users.Items = allUsers.OrderByDescending(e => e.Firstname).Skip(skip).Take(pageSize).ToList();
            }
            else if (sortBy.ToLower() == "lastname" && sortOrder.ToLower() == "asc")
            {
                Users.Items = allUsers.OrderBy(e => e.Lastname).Skip(skip).Take(pageSize).ToList();
            }
            else
            {
                Users.Items = allUsers.OrderByDescending(e => e.Lastname).Skip(skip).Take(pageSize).ToList();
            }

            Users.PageCount = pageCount;
            Users.PageIndex = pageIndex;
            Users.PageSize = pageSize;
            Users.QueryCount = queryCount;

            return Users;

        }
        public static Operation Add(Models.User user)
        {
            try
            {
                db.Users.Add(user);
                db.SaveChanges();

                return new Operation()
                {
                    Code = "200",
                    Message = "Ok",
                    ReferenceId = user.Id
                };
            }
            catch (Exception e)
            {
                return new Operation()
                {
                    Code = "500",
                    Message = e.Message
                };

               
            }
        }
        public static Operation Update(Models.User newRecord)
        {
            try
            {
                Models.User oldRecord = db.Users.FirstOrDefault(e => e.Id == newRecord.Id);

                if (oldRecord != null)
                {

                    oldRecord.EmailAddress = newRecord.EmailAddress;
                    oldRecord.Firstname = newRecord.Firstname;
                    oldRecord.Lastname = newRecord.Lastname;
             


                    db.SaveChanges();

                    return new Operation()
                    {
                        Code = "200",
                        Message = "OK"
                    };
                }


                return new Operation()
                {
                    Code = "500",
                    Message = "Not found"
                };
            }
            catch (Exception e)
            {
                return new Operation()
                {
                    Code = "500",
                    Message = e.Message
                };
            }
        }

        public static Models.User GetbyId(Guid? id)
        {
            return db.Users.FirstOrDefault(u => u.Id == id);
        }

        public static Operation Login(string emailAddress = "", string password = "")
        {
            if (string.IsNullOrEmpty(emailAddress))
            {
                return new Operation()
                {
                    Code = "500",
                    Message = "Invalid Login"
                };
            }

            if (string.IsNullOrEmpty(password))
            {
                return new Operation()
                {
                    Code = "500",
                    Message = "Invalid Login"
                };
            }

            try
            {
               Models.User user = db.Users.FirstOrDefault(e => e.EmailAddress.ToLower() == emailAddress.ToLower());

                if (user == null)
                {
                    return new Operation()
                    {
                        Code = "500",
                        Message = "Invalid Login"
                    };
                }

                if (password == user.Password)
                {
                    return new Operation()
                    {
                        Code = "200",
                        Message = "Successful Login",
                        ReferenceId = user.Id
                    };
                }

                return new Operation()
                {
                    Code = "500",
                    Message = "Invalid Login"
                };
            }
            catch (Exception e)
            {
                return new Operation()
                {
                    Code = "500",
                    Message = e.Message
                };
            }
        }
    }



}
    

