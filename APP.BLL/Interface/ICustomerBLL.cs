using APP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.BLL.Interface
{
    public interface ICustomerBLL
    {
        IList<CustomerModel> GetAll();
        int SaveOrUpdate(CustomerModel customer);
        int Delete(CustomerModel customerModel);
    }
}
