using APP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.BLL.Interface
{
    public interface IEventTypeBLL
    {
        IList<EventTypeModel> GetAll();
        int SaveOrUpdate(EventTypeModel eventType);
        int Delete(EventTypeModel eventTypeModel);
    }
}
