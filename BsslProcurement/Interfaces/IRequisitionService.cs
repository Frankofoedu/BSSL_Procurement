﻿using DcProcurement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BsslProcurement.Interfaces
{
    public interface IRequisitionService
    {
        Task<List<Requisition>> GetRequisitionsForLoggedInUser(string userId);

        Task<List<Requisition>> GetBudgetClearedRequisitions();

        Task SendRequisitionToNextStageAsync(Requisition requisition, string staffId, int currStage, string remark);
        Task SendRequisitionToPreviousStage();
        Task ReAssignRequisition();
    }
}
