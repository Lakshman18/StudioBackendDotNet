using APP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.BLL.Interface
{
    public interface IEventSubTypeBLL
    {
        IList<EventSubTypeModel> GetAll();
        int SaveOrUpdate(EventSubTypeModel eventSubType);
        int Delete(EventSubTypeModel eventSubType);
    }
}
