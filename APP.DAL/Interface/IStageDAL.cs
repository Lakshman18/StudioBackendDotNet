﻿using APP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.DAL.Interface
{
    public interface IStageDAL
    {
        IList<Stage> GetAll();
        int SaveOrUpdate(Stage stage);
        int Delete(Stage stage);
    }
}
