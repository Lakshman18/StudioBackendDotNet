using APP.DAL.Entities;
using APP.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.DAL.Repository
{
    public class CustomerDAL: ICustomerDAL
    {
        private readonly StudioDbContext db;
        public CustomerDAL()
        {
            db = new StudioDbContext();
        }

        public IList<Customer> GetAll()
        {
            return db.Customers.Where(x => x.IsActive == true).ToList();
        }

        public int SaveOrUpdate(Customer customer)
        {
            if (customer.Id > 0)
            {
                Customer c = new Customer();
                c = db.Customers.AsNoTracking().FirstOrDefault(x => x.Id == customer.Id);

                if (c == null)
                    throw new Exception("Not Found");
                db.Customers.Update(setData(customer, c));
                db.SaveChanges();
            }
            else
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }

            return customer.Id;
        }

        public int Delete(Customer customer)
        {
            Customer c = new Customer();
            c = db.Customers.AsNoTracking().FirstOrDefault(x => x.Id == customer.Id);

            if (c == null)
                throw new Exception("Not Found");

            customer.IsActive = false;
            db.Customers.Update(setData(customer, c));
            db.SaveChanges();

            return c.Id;
        }

        private Customer setData(Customer customer, Customer original)
        {
            customer.CreatedDate = original.CreatedDate;
            customer.CreatedBy = original.CreatedBy;

            return customer;
        }

    }
}
