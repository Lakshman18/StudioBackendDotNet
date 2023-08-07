using APP.BLL.Interface;
using APP.DAL.Entities;
using APP.DAL.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.BLL.Service
{
    public class UserBLL: IUserBLL
    {
        private readonly IUserDAL _userDAL;
        private Mapper _Mapper;

        public UserBLL(IUserDAL userDAL)
        {
            _userDAL = userDAL;
            var _config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>().ReverseMap());
            _Mapper = new Mapper(_config);
        }

        public UserModel Login(UserModel userModel)
        {
            User entityModel = _Mapper.Map<UserModel, User>(userModel);
            User res = _userDAL.Login(entityModel);
            return _Mapper.Map<User, UserModel>(res);
        }

        public int ChangePassword(UserModel userModel)
        {
            User entityModel = _Mapper.Map<UserModel, User>(userModel);
            return _userDAL.ChangePassword(entityModel);
        }

        public UserModel GetUser(string token)
        {
            User res = _userDAL.GetUser(token);
            return _Mapper.Map<User, UserModel>(res);
        }
    }
}
