﻿using MalignantTumorSystem.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalignantTumorSystem.IBLL
{
    public partial interface IChronic_disease_Comm_HumorService : IBaseService<Chronic_disease_Comm_Humor>
    {
        IQueryable<Model.Entities.Chronic_disease_Comm_Humor> LoadSearchEntities(Model.SearchParam.CommonParam parms);
    }
}
