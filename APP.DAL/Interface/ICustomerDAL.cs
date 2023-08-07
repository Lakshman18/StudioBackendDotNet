using APP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.DAL.Interface
{
    public interface ICustomerDAL
    {
        IList<Customer> GetAll();
        int SaveOrUpdate(Customer customer);
        int Delete(Customer customer);
    }
}
