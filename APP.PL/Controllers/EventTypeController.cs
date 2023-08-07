using APP.BLL.Interface;
using APP.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace APP.PL.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EventTypeController : ControllerBase
    {
        private readonly IEventTypeBLL _EventTypeBLL;

        public EventTypeController(IEventTypeBLL EventTypeBLL)
        {
            _EventTypeBLL = EventTypeBLL;
        }

        [HttpGet]
        [Route("GetAll")]
        public IList<EventTypeModel> GetAll()
        {
            return _EventTypeBLL.GetAll();
        }

        [HttpPost]
        [Route("SaveOrUpdate")]
        public int SaveOrUpdate(EventTypeModel eventTypeModel)
        {
            return _EventTypeBLL.SaveOrUpdate(setData(eventTypeModel));
        }

        [HttpPost]
        [Route("Delete")]
        public int Delete(EventTypeModel eventTypeModel)
        {
            return _EventTypeBLL.Delete(setData(eventTypeModel));
        }

        private EventTypeModel setData(EventTypeModel eventTypeModel)
        {
            if (eventTypeModel.Id > 0)
            {
                eventTypeModel.UpdatedDate = DateTime.Now;
                eventTypeModel.UpdatedBy = Int32.Parse(User.FindFirstValue("UserId"));
            }
            else
            {
                eventTypeModel.CreatedDate = DateTime.Now;
                eventTypeModel.UpdatedDate = DateTime.Now;
                eventTypeModel.CreatedBy = Int32.Parse(User.FindFirstValue("UserId"));
                eventTypeModel.UpdatedBy = Int32.Parse(User.FindFirstValue("UserId"));
            }
            return eventTypeModel;
        }

    }
}
