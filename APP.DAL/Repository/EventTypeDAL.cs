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
    public class EventTypeDAL: IEventTypeDAL
    {
        private readonly StudioDbContext db;
        public EventTypeDAL()
        {
            db = new StudioDbContext();
        }

        public IList<EventType> GetAll()
        {
            return db.EventTypes.Where(x => x.IsActive == true).ToList();
        }

        public int SaveOrUpdate(EventType eventType)
        {
            if (eventType.Id > 0)
            {
                EventType c = new EventType();
                c = db.EventTypes.AsNoTracking().FirstOrDefault(x => x.Id == eventType.Id);

                if (c == null)
                    throw new Exception("Not Found");
                db.EventTypes.Update(setData(eventType, c));
                db.SaveChanges();
            }
            else
            {
                db.EventTypes.Add(eventType);
                db.SaveChanges();
            }

            return eventType.Id;
        }

        public int Delete(EventType eventType)
        {
            EventType c = new EventType();
            c = db.EventTypes.AsNoTracking().FirstOrDefault(x => x.Id == eventType.Id);

            if (c == null)
                throw new Exception("Not Found");

            eventType.IsActive = false;
            db.EventTypes.Update(setData(eventType, c));
            db.SaveChanges();

            return c.Id;
        }

        private EventType setData(EventType eventType, EventType original)
        {
            eventType.CreatedDate = original.CreatedDate;
            eventType.CreatedBy = original.CreatedBy;

            return eventType;
        }

    }
}
