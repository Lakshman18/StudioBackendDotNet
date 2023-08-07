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
    public class StageDAL: IStageDAL
    {
        private readonly StudioDbContext db;
        public StageDAL()
        {
            db = new StudioDbContext();
        }

        public IList<Stage> GetAll()
        {
            return db.Stages.Where(x => x.IsActive == true).ToList();
        }

        public int SaveOrUpdate(Stage stage)
        {
            if (stage.Id > 0)
            {
                Stage c = new Stage();
                c = db.Stages.AsNoTracking().FirstOrDefault(x => x.Id == stage.Id);

                if (c == null)
                    throw new Exception("Not Found");
                db.Stages.Update(setData(stage, c));
                db.SaveChanges();
            }
            else
            {
                db.Stages.Add(stage);
                db.SaveChanges();
            }

            return stage.Id;
        }

        public int Delete(Stage stage)
        {
            Stage c = new Stage();
            c = db.Stages.AsNoTracking().FirstOrDefault(x => x.Id == stage.Id);

            if (c == null)
                throw new Exception("Not Found");

            stage.IsActive = false;
            db.Stages.Update(setData(stage, c));
            db.SaveChanges();

            return c.Id;
        }

        private Stage setData(Stage stage, Stage original)
        {
            stage.CreatedDate = original.CreatedDate;
            stage.CreatedBy = original.CreatedBy;

            return stage;
        }

    }
}
