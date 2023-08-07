using APP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.BLL.Interface
{
    public interface IStageBLL
    {
        IList<StageModel> GetAll();
        int SaveOrUpdate(StageModel stage);
        int Delete(StageModel stageModel);
    }
}
