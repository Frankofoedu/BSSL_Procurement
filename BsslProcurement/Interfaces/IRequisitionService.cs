﻿using BsslProcurement.ViewModels;
using DcProcurement;
using DcProcurement.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BsslProcurement.Interfaces
{
    public interface IRequisitionService
    {
        Task<List<RequisitionJob>> GetRequisitionsJobsAssignedToLoggedInUser(string userId);
        Task<List<Requisition>> GetRequisitionsForLoggedInUser(string userId);
        Task<List<Requisition>> GetSavedRequisitionsForLoggedInUser(string userId);
        Task<List<Requisition>> GetSubmittedRequisitionsForLoggedInUser(string userId);
        Task<List<Requisition>> GetApprovedRequisitionsForLoggedInUser(string userId);


        Task<WorkFlowApproverViewModel> GetCurrentWorkFlowOFRequisition(Requisition requisition);

        Task DeleteRequisitionItem(int reqItemId);
        Task SendRequisitionToNextStageAsync(int requisitionId, string staffCode, int newStage, string remark);
        Task CreateInitiatorJobAsync(int requisitionId, string staffId, string remark, bool isRejected);
        Task SendRequisitionToPreviousStage(int requisitionId, string currStaffCode, string newStaffCode, int newStage, string remark);
        Task ReAssignRequisition(Requisition requisition, string currStaffCode, string newStaffCode);
        Task SendToQuarantine(int requisitionId, string remark);
        Task RejectRequisition(int requisitionId, string rejectionRemark);

    }
}
