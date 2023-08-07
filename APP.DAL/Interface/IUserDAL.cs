using APP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.DAL.Interface
{
    public  interface IUserDAL
    {
        User Login(User user);
        int ChangePassword(User user);
        User GetUser(string token);
    }
}
