using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    interface IUserRepository
    {
      

        List<User> GetAll();
        User Get(int id);
        User GetMatchBlood(string bloodgroup);
        int Insert(User user);
        int Update(User user);
        int Delete(int id);

        User LoginValidation(User user);
       
    }
}
