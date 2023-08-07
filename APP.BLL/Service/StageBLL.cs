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
    public class StageBLL: IStageBLL
    {
        private readonly IStageDAL _StageDAL;
        private Mapper _Mapper;

        public StageBLL(IStageDAL StageDAL)
        {
            _StageDAL = StageDAL;
            var _config = new MapperConfiguration(cfg => cfg.CreateMap<Stage, StageModel>().ReverseMap());
            _Mapper = new Mapper(_config);
        }

        public IList<StageModel> GetAll()
        {
            IList<Stage> entities = _StageDAL.GetAll();
            IList<StageModel> entityModels = _Mapper.Map<IList<Stage>, IList<StageModel>>(entities);
            return entityModels;
        }

        public int SaveOrUpdate(StageModel stage)
        {
            Stage entityModel = _Mapper.Map<StageModel, Stage>(stage);
            return _StageDAL.SaveOrUpdate(entityModel);
        }

        public int Delete(StageModel stage)
        {
            Stage entityModel = _Mapper.Map<StageModel, Stage>(stage);
            return _StageDAL.Delete(entityModel);
        }

    }
}
