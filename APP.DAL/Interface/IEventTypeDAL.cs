using APP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.DAL.Interface
{
    public interface IEventTypeDAL
    {
        IList<EventType> GetAll();
        int SaveOrUpdate(EventType eventType);
        int Delete(EventType eventType);
    }
}
