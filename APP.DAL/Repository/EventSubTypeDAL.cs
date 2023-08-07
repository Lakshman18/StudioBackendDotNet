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
    public class EventSubTypeDAL : IEventSubTypeDAL
    {
        private readonly StudioDbContext db;
        public EventSubTypeDAL()
        {
            db = new StudioDbContext();
        }

        public IList<EventSubType> GetAll()
        {
            return db.EventSubTypes
                .Where(x => x.IsActive == true)
                .Include("EventType")
                .ToList();
        }

        public int SaveOrUpdate(EventSubType eventSubType)
        {
            if (eventSubType.Id > 0)
            {
                EventSubType c = new EventSubType();
                c = db.EventSubTypes.AsNoTracking().FirstOrDefault(x => x.Id == eventSubType.Id);

                if (c == null)
                    throw new Exception("Not Found");
                db.EventSubTypes.Update(setData(eventSubType, c));
                db.SaveChanges();
            }
            else
            {
                db.EventSubTypes.Add(eventSubType);
                db.SaveChanges();
            }

            return eventSubType.Id;
        }

        public int Delete(EventSubType eventSubType)
        {
            EventSubType c = new EventSubType();
            c = db.EventSubTypes.AsNoTracking().FirstOrDefault(x => x.Id == eventSubType.Id);

            if (c == null)
                throw new Exception("Not Found");

            eventSubType.IsActive = false;
            db.EventSubTypes.Update(setData(eventSubType, c));
            db.SaveChanges();

            return c.Id;
        }

        private EventSubType setData(EventSubType eventSubType, EventSubType original)
        {
            eventSubType.CreatedDate = original.CreatedDate;
            eventSubType.CreatedBy = original.CreatedBy;

            return eventSubType;
        }

    }
}
