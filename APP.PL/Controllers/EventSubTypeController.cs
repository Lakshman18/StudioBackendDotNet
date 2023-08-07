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
    public class EventSubTypeController : ControllerBase
    {
        private readonly IEventSubTypeBLL _EventSubTypeBLL;

        public EventSubTypeController(IEventSubTypeBLL EventSubTypeBLL)
        {
            _EventSubTypeBLL = EventSubTypeBLL;
        }

        [HttpGet]
        [Route("GetAll")]
        public IList<EventSubTypeModel> GetAll()
        {
            return _EventSubTypeBLL.GetAll();
        }

        [HttpPost]
        [Route("SaveOrUpdate")]
        public int SaveOrUpdate(EventSubTypeModel eventSubTypeModel)
        {
            return _EventSubTypeBLL.SaveOrUpdate(setData(eventSubTypeModel));
        }

        [HttpPost]
        [Route("Delete")]
        public int Delete(EventSubTypeModel eventSubTypeModel)
        {
            return _EventSubTypeBLL.Delete(setData(eventSubTypeModel));
        }

        private EventSubTypeModel setData(EventSubTypeModel eventSubTypeModel)
        {
            if (eventSubTypeModel.Id > 0)
            {
                eventSubTypeModel.UpdatedDate = DateTime.Now;
                eventSubTypeModel.UpdatedBy = Int32.Parse(User.FindFirstValue("UserId"));
            }
            else
            {
                eventSubTypeModel.CreatedDate = DateTime.Now;
                eventSubTypeModel.UpdatedDate = DateTime.Now;
                eventSubTypeModel.CreatedBy = Int32.Parse(User.FindFirstValue("UserId"));
                eventSubTypeModel.UpdatedBy = Int32.Parse(User.FindFirstValue("UserId"));
            }
            return eventSubTypeModel;
        }

    }
}
