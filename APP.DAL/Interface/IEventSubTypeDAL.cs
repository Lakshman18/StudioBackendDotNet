using APP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.DAL.Interface
{
    public interface IEventSubTypeDAL
    {
        IList<EventSubType> GetAll();
        int SaveOrUpdate(EventSubType eventSubType);
        int Delete(EventSubType eventSubType);
    }
}
