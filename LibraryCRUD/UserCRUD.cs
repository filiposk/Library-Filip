using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class UserCRUD
    {
        private LibraryEntities DbContext;

        private UserCRUD()
        {
            DbContext = new LibraryEntities();
        }

        public List<User> GetAllUsers()
        {
            return this.DbContext.Users.ToList();
        }

        public User GetUsers(int userId)
        {
            return this.DbContext.Users.Where(p => p.Id == userId).FirstOrDefault();
        }

        public bool CreateUser(User userItem)
        {
            bool status;

            try
            {
                this.DbContext.Users.Add(userItem);
                this.DbContext.SaveChanges();
                status = true;
            }

            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public bool UpdateUser(User userItem)
        {
            bool status;

            try
            {
                User user = this.DbContext.Users.Where(p => p.Id == userItem.Id).FirstOrDefault();
                if (user != null)
                {
                    user.Id = userItem.Id;
                    user.Email = userItem.Email;
                    user.Password = userItem.Password;
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public bool DeleteUser(int userId)
        {
            bool status;
            try
            {
                User user = this.DbContext.Users.Where(p => p.Id == userId).SingleOrDefault();
                if (user != null)
                {
                    this.DbContext.Users.Remove(user);
                    this.DbContext.SaveChanges();
                }
                status = true;
            }

            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}
