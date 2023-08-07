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
    public class EventTypeBLL: IEventTypeBLL
    {
        private readonly IEventTypeDAL _EventTypeDAL;
        private Mapper _Mapper;

        public EventTypeBLL(IEventTypeDAL EventTypeDAL)
        {
            _EventTypeDAL = EventTypeDAL;
            var _config = new MapperConfiguration(cfg => cfg.CreateMap<EventType, EventTypeModel>().ReverseMap());
            _Mapper = new Mapper(_config);
        }

        public IList<EventTypeModel> GetAll()
        {
            IList<EventType> entities = _EventTypeDAL.GetAll();
            IList<EventTypeModel> entityModels = _Mapper.Map<IList<EventType>, IList<EventTypeModel>>(entities);
            return entityModels;
        }

        public int SaveOrUpdate(EventTypeModel eventType)
        {
            EventType entityModel = _Mapper.Map<EventTypeModel, EventType>(eventType);
            return _EventTypeDAL.SaveOrUpdate(entityModel);
        }

        public int Delete(EventTypeModel eventType)
        {
            EventType entityModel = _Mapper.Map<EventTypeModel, EventType>(eventType);
            return _EventTypeDAL.Delete(entityModel);
        }

    }
}
