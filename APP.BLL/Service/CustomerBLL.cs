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
    public class CustomerBLL: ICustomerBLL
    {
        private readonly ICustomerDAL _CustomerDAL;
        private Mapper _Mapper;

        public CustomerBLL(ICustomerDAL CustomerDAL)
        {
            _CustomerDAL = CustomerDAL;
            var _config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerModel>().ReverseMap());
            _Mapper = new Mapper(_config);
        }

        public IList<CustomerModel> GetAll()
        {
            IList<Customer> entities = _CustomerDAL.GetAll();
            IList<CustomerModel> entityModels = _Mapper.Map<IList<Customer>, IList<CustomerModel>>(entities);
            return entityModels;
        }

        public int SaveOrUpdate(CustomerModel customer)
        {
            Customer entityModel = _Mapper.Map<CustomerModel, Customer>(customer);
            return _CustomerDAL.SaveOrUpdate(entityModel);
        }

        public int Delete(CustomerModel customer)
        {
            Customer entityModel = _Mapper.Map<CustomerModel, Customer>(customer);
            return _CustomerDAL.Delete(entityModel);
        }

    }
}
