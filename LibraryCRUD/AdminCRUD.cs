using DataAccesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRUD
{
    public class AdminCRUD
    {
        private LibraryDatabaseEntities DbContext;

        private AdminCRUD()
        {
            DbContext = new LibraryDatabaseEntities();
        }

        public List<Admin> GetAllAdmins()
        {
            return this.DbContext.Admins.ToList();
        }

        public Admin GetUAdmins(int userId)
        {
            return this.DbContext.Admins.Where(p => p.Id == userId).FirstOrDefault();
        }

        public bool CreateAdmins(Admin adminItem)
        {
            bool status;

            try
            {
                this.DbContext.Admins.Add(adminItem);
                this.DbContext.SaveChanges();
                status = true;
            }

            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public bool UpdateAdmin(Admin adminItem)
        {
            bool status;

            try
            {
                Admin admin = this.DbContext.Admins.Where(p => p.Id == adminItem.Id).FirstOrDefault();
                if (admin != null)
                {
                    admin.Id = adminItem.Id;
                    admin.Email = adminItem.Email;
                    admin.Password = adminItem.Password;
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public bool DeleteAdmin(int adminId)
        {
            bool status;
            try
            {
                Admin admin = this.DbContext.Admins.Where(p => p.Id == adminId).SingleOrDefault();
                if (admin != null)
                {
                    this.DbContext.Admins.Remove(admin);
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
