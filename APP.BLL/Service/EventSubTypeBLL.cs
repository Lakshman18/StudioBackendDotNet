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
    public class EventSubTypeBLL: IEventSubTypeBLL
    {
        private readonly IEventSubTypeDAL _EventSubTypeDAL;
        private Mapper _Mapper;

        public EventSubTypeBLL(IEventSubTypeDAL EventSubTypeDAL)
        {
            _EventSubTypeDAL = EventSubTypeDAL;
            var _config = new MapperConfiguration(cfg => cfg.CreateMap<EventSubType, EventSubTypeModel>().ReverseMap()
            .ForMember(c => c.EventType, ocfg => cfg.CreateMap<EventType, EventTypeModel>()).ReverseMap());
            _Mapper = new Mapper(_config);
        }

        public IList<EventSubTypeModel> GetAll()
        {
            IList<EventSubType> entities = _EventSubTypeDAL.GetAll();
            IList<EventSubTypeModel> entityModels = _Mapper.Map<IList<EventSubType>, IList<EventSubTypeModel>>(entities);
            foreach (var entityModel in entityModels)
            {
                entityModel.EventTypeName = entityModel.EventType != null ? entityModel.EventType.Name : "-";
            }
            return entityModels;
        }

        public int SaveOrUpdate(EventSubTypeModel eventSubType)
        {
            EventSubType entityModel = _Mapper.Map<EventSubTypeModel, EventSubType>(eventSubType);
            return _EventSubTypeDAL.SaveOrUpdate(entityModel);
        }

        public int Delete(EventSubTypeModel eventSubType)
        {
            EventSubType entityModel = _Mapper.Map<EventSubTypeModel, EventSubType>(eventSubType);
            return _EventSubTypeDAL.Delete(entityModel);
        }

    }
}
