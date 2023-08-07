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
    public class StageController : ControllerBase
    {
        private readonly IStageBLL _StageBLL;

        public StageController(IStageBLL StageBLL)
        {
            _StageBLL = StageBLL;
        }

        [HttpGet]
        [Route("GetAll")]
        public IList<StageModel> GetAll()
        {
            return _StageBLL.GetAll();
        }

        [HttpPost]
        [Route("SaveOrUpdate")]
        public int SaveOrUpdate(StageModel stageModel)
        {
            return _StageBLL.SaveOrUpdate(setData(stageModel));
        }

        [HttpPost]
        [Route("Delete")]
        public int Delete(StageModel stageModel)
        {
            return _StageBLL.Delete(setData(stageModel));
        }

        private StageModel setData(StageModel stageModel)
        {
            if (stageModel.Id > 0)
            {
                stageModel.UpdatedDate = DateTime.Now;
                stageModel.UpdatedBy = Int32.Parse(User.FindFirstValue("UserId"));
            }
            else
            {
                stageModel.CreatedDate = DateTime.Now;
                stageModel.UpdatedDate = DateTime.Now;
                stageModel.CreatedBy = Int32.Parse(User.FindFirstValue("UserId"));
                stageModel.UpdatedBy = Int32.Parse(User.FindFirstValue("UserId"));
            }
            return stageModel;
        }

    }
}
