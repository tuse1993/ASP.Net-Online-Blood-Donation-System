using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    interface IAdminRepository
    {

        List<Admin> GetAll();
        User Get(int id);
        int Insert(Admin admins);
        int Update(Admin admins);
        int Delete(int id);

        Admin LoginValidation(Admin admins);
    }
}
