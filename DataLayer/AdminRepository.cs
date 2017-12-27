using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AdminRepository : IAdminRepository
    {
        private DataContext context;

        public AdminRepository() { this.context = new DataContext(); }

        public List<Admin> GetAll()
        {
            return this.context.Admins.ToList();
        }

        public Admin Get(int id)
        {
            return this.context.Admins.SingleOrDefault(e => e.Id == id);
        }

        public int Insert(Admin ad)
        {
            this.context.Admins.Add(ad);
            return this.context.SaveChanges();
        }

        public int Update(Admin admin)
        {
            Admin adminToUpdate = this.context.Admins.SingleOrDefault(e => e.Id == admin.Id);
            adminToUpdate.userName = admin.userName;
            adminToUpdate.password = admin.password;
           


            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            Admin adminToDelete = this.context.Admins.SingleOrDefault(e => e.Id == id);
            this.context.Admins.Remove(adminToDelete);

            return this.context.SaveChanges();
        }

        public Admin LoginValidation(Admin ad)
        {
           var adm = this.context.Admins.Where(u => u.userName == ad.userName && u.password == ad.password).FirstOrDefault();

            if(adm != null)
            {
               Admin u = adm;
               return u;
            }
           else
            {
                return null;
            }   
        }

        User IAdminRepository.Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
