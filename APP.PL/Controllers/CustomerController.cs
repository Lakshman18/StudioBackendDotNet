using APP.BLL.Interface;
using APP.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace APP.PL.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerBLL _CustomerBLL;

        public CustomerController(ICustomerBLL CustomerBLL)
        {
            _CustomerBLL = CustomerBLL;
        }

        [HttpGet]
        [Route("GetAll")]
        public IList<CustomerModel> GetAll()
        {
            return _CustomerBLL.GetAll();
        }

        [HttpPost]
        [Route("SaveOrUpdate")]
        public int SaveOrUpdate(CustomerModel customerModel)
        {
            return _CustomerBLL.SaveOrUpdate(setData(customerModel));
        }

        [HttpPost]
        [Route("Delete")]
        public int Delete(CustomerModel customerModel)
        {
            return _CustomerBLL.Delete(setData(customerModel));
        }

        private CustomerModel setData(CustomerModel customerModel)
        {
            if (customerModel.Id > 0)
            {
                customerModel.UpdatedDate = DateTime.Now;
                customerModel.UpdatedBy = Int32.Parse(User.FindFirstValue("UserId"));
            }
            else
            {
                customerModel.CreatedDate = DateTime.Now;
                customerModel.UpdatedDate = DateTime.Now;
                customerModel.CreatedBy = Int32.Parse(User.FindFirstValue("UserId"));
                customerModel.UpdatedBy = Int32.Parse(User.FindFirstValue("UserId"));
            }
            return customerModel;
        }

    }
}
