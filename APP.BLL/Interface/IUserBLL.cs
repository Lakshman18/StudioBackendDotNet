using APP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.BLL.Interface
{
    public interface IUserBLL
    {
        UserModel Login(UserModel user);
        int ChangePassword(UserModel userModel);

        UserModel GetUser(string token);
    }
}
