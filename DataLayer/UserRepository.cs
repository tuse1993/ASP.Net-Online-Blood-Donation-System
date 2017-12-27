using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserRepository : IUserRepository
    {
        private DataContext context;

        public UserRepository() { this.context = new DataContext(); }

        public List<User> GetAll()
        {
            return this.context.Users.ToList();
        }

        public User Get(int id)
        {
            return this.context.Users.SingleOrDefault(e => e.Id == id);
        }
        public User GetMatchBlood(string bloodgroup )
        {
            return this.context.Users.SingleOrDefault(e => e.bloodGroup == bloodgroup);
        }

        public List<User> GetBlood(User user)
        {
            return this.context.Users.ToList();
        }


        public int Insert(User user)
        {
            this.context.Users.Add(user);
            return this.context.SaveChanges();
        }

        public int Update(User user)
        {
            User userToUpdate = this.context.Users.SingleOrDefault(e => e.Id == user.Id);
            userToUpdate.userName = user.userName;
            userToUpdate.fullName = user.fullName;
            userToUpdate.gender = user.gender;
            userToUpdate.password = user.password;
            userToUpdate.age = user.age;
            userToUpdate.weight = user.weight;
            userToUpdate.bloodGroup = user.bloodGroup;
            userToUpdate.mobileNumber = user.mobileNumber;
            userToUpdate.email = user.email;
            userToUpdate.address = user.address;
            userToUpdate.division = user.division;
            userToUpdate.available = user.available;
           


            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            User userToDelete = this.context.Users.SingleOrDefault(e => e.Id == id);
            this.context.Users.Remove(userToDelete);

            return this.context.SaveChanges();
        }

        public User LoginValidation(User user)
        {
           var usr = this.context.Users.Where(u => u.userName == user.userName && u.password == user.password).FirstOrDefault();

            if(usr != null)
            {
               User u = usr;
               return u;
            }
           else
            {
                return null;
            }   
        }
    }
}
