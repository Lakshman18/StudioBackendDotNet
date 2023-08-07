using APP.BLL.Interface;
using APP.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBLL _UserBLL;

        public UserController(IUserBLL userBLL)
        {
            _UserBLL = userBLL;
        }

        [HttpPost]
        [Route("Login")]
        public UserModel Login(UserModel user)
        {
            return _UserBLL.Login(user);
        }

        [HttpPost]
        [Authorize]
        [Route("ChangePassword")]
        public int ChangePassword(UserModel user)
        {
            return _UserBLL.ChangePassword(user);
        }

        [HttpPost]
        [Authorize]
        [Route("GetUser")]
        public UserModel GetUser([FromQuery] string token)
        {
            return _UserBLL.GetUser(token);
        }
    }
}
