﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BsslProcurement.Filters.Attributes;
using BsslProcurement.Interfaces;
using BsslProcurement.Services;
using BsslProcurement.UtilityMethods;
using BsslProcurement.ViewModels;
using DcProcurement;
using DcProcurement.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace BsslProcurement.Pages.Staff.ItemRequisition
{

    [DisplayName("New Requisition")]
    [Authorize]
    [NoDiscovery]
    public class NewRequisitionModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly BSSLSYS_ITF_DEMOContext _bsslContext;
        private readonly ProcurementDBContext _procContext;
        private readonly IWebHostEnvironment _environment;
        private readonly IRequisitionService _requisitionService;


        public string Message { get; set; }
        public string Error { get; set; }
        [BindProperty]
        public string PrNo { get; set; }

        [BindProperty]
        public List<ItemGridViewModel> gridVm { get; set; }

        //[BindProperty]
        //public IFormFile File { get; set; }

        [BindProperty]
        public string RequestingDept { get; set; }

        [BindProperty]
        public string RequestingDeptCode { get; set; }

        [BindProperty]
        public List<SelectListItem> Departments { get; set; }

        [BindProperty]
        public Requisition Requisition { get; set; }
        [BindProperty]
        public WorkFlowApproverViewModel WfVm { get; set; }
        public NewRequisitionModel(UserManager<User> userManager,
            BSSLSYS_ITF_DEMOContext bsslContext,
            ProcurementDBContext procContext, IRequisitionService requisitionService, IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _bsslContext = bsslContext;
            _procContext = procContext;
            _environment = environment;
            _requisitionService = requisitionService;
        }

        public async Task<ActionResult> OnGetAsync(int? id)
        {
            try
            {
                if (id != null)
                {
                    Requisition = _procContext.Requisitions.Include(x => x.RequisitionItems).ThenInclude(c => c.Attachment).FirstOrDefault( c => c.Id == id);
                    
                    if (Requisition == null)
                    {
                        Error = "No requisition found";
                        return Page();
                    }

                    gridVm = await LoadGridViewItemsFromRequisition(Requisition, _environment);
                }
                await LoadData();
            }
            catch (Exception ex)
            {
                Error = $"An error occured. Please contact Support. {ex.Message}";
            }

            return Page();
        }

        public async Task<ActionResult> OnPostSubmitAsync()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //save requisition
                    await SaveOrSubmitRequisition(true);

                    //create and assign requisition job
                   await _requisitionService.SendRequisitionToNextStageAsync(Requisition.Id, 
                       WfVm.AssignedStaffCode, WfVm.WorkFlowId, WfVm.Remark);
                    

                    Message = "Requisition Added successfully";
                   // return RedirectToPage("AllRequisition");
                }
                catch (Exception ex)
                {
                    Error = "An error has occurred." + Environment.NewLine + ex.Message;
                }
            }

            await LoadData();
            return Page();
        }

        public async Task<ActionResult> OnPostSaveAsync()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await SaveOrSubmitRequisition(false);
                    
                    return RedirectToPage("SavedRequisitions");
                }
                catch (Exception ex)
                {
                    Error = "An error has occurred." + Environment.NewLine + ex.Message;
                }

            }

            await LoadData();
            return Page();
        }

        private async Task LoadData()
        {

            //load requisition workflow
            var workflow = _procContext.WorkflowTypes.Include(c=> c.Workflows).FirstOrDefault(x => x.Name == DcProcurement.Constants.RequisitionWorkflow);

            if (workflow.Workflows.Count > 0)
            {
                WfVm = new WorkFlowApproverViewModel { WorkFlowTypeId = workflow.Id};
            }
            //get current logged in user
            var loggedInUserCode = (await GetCurrentUserAsync()).Id;
            (PrNo, RequestingDeptCode, RequestingDept, Departments) = await GeneratePRNo(loggedInUserCode);
        }

        private async Task<List<ItemGridViewModel>> LoadGridViewItemsFromRequisition(Requisition requisition, IWebHostEnvironment env)
        {
             FormFile CreateFormFile(string filename)
            {
              var fn = System.IO.Path.Combine(env.WebRootPath,filename);
              
                using var stream = System.IO.File.OpenRead(fn);
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                    Headers = new HeaderDictionary(),
                    ContentType = "application/pdf"
                };

                return file;
            }

            try
            {

                return requisition.RequisitionItems.Select(x => new ItemGridViewModel { RequisitionItem = x, Attachment = CreateFormFile(x.Attachment.FilePath) }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        private async Task SaveOrSubmitRequisition(bool isSubmitted)
        {
            //save requisition items
            Requisition.RequisitionItems = await GetRequisitionItemsFromViewModel(gridVm);   
                       
            Requisition.isSubmitted = isSubmitted;

            Requisition.Status = isSubmitted ? "Sent For Processing" : "Saved";

            Requisition.LoggedInUserId = (await GetCurrentUserAsync()).Id;

            _procContext.Requisitions.Add(Requisition);

            _procContext.SaveChanges();
            
        }

        private async Task<List<RequisitionItem>> GetRequisitionItemsFromViewModel(List<ItemGridViewModel> gridVm)
        {
            List<RequisitionItem> reList = new List<RequisitionItem>();
            foreach (ItemGridViewModel v in gridVm)
            {
                RequisitionItem re = v.RequisitionItem;
                if (v.Attachment != null)
                {
                    re.Attachment = await FileUpload.GetFilePathsFromFileAsync(v.Attachment, _environment, "Attachment");                   

                }
                else
                {
                    re.Attachment = null;
                }
                reList.Add(re);
            }
            return reList;
        }

        
        public PartialViewResult OnGetVendorPartial()
        {

            //get all vendor 
            var vendors = _procContext.Vendors.ToList();


            //           var  = _bsslContext.Stafftab.ToList();
            return new PartialViewResult
            {
                ViewName = "_VendorLayoutModal",
                ViewData = new ViewDataDictionary<List<VendorUser>>(ViewData, vendors)
            };
        }

        public PartialViewResult OnGetApproverPartial()
        {
            return new PartialViewResult
            {
                ViewName = "Modals/_SelectApproverPartial",
                ViewData = new ViewDataDictionary<List<int>>(ViewData, new List<int>() { 1, 2 })
            };
        }

        public class requesterObj
        {
            public string code { get; set; }
            public string name { get; set; }
            public string type { get; set; }
        }

        public PartialViewResult OnGetRequesterPartial(string type)
        {
            //get requester

            var requesters = new List<requesterObj>();

            if (type.ToLower() == "department")
            {
                requesters = _bsslContext.Codestab.Where(opt => opt.Option1 == "F5")
                    .Select(m=> new requesterObj() { code = m.Code, name=m.Desc1, type=type }).ToList();
            }
            else if (type.ToLower() == "division")
            {
                requesters = _bsslContext.Codestab.Where(opt => opt.Option1 == "Div")
                    .Select(m => new requesterObj() { code = m.Code, name = m.Desc1, type = type }).ToList();
            }
            else if (type.ToLower() == "section")
            {
                requesters = _bsslContext.Codestab.Where(opt => opt.Option1 == "SECT")
                    .Select(m => new requesterObj() { code = m.Code, name = m.Desc1, type = type }).ToList();
            }
            else if (type.ToLower() == "unit")
            {
                requesters = _bsslContext.Codestab.Where(opt => opt.Option1 == "Z16")
                    .Select(m => new requesterObj() { code = m.Code, name = m.Desc1, type = type }).ToList();
            }
            else if (type.ToLower() == "staff")
            {
                requesters = _bsslContext.Stafftab.Select(x => new requesterObj { code = x.Staffid, name = x.Surname + x.Othernames, type = type }).ToList();
            }

            return new PartialViewResult
            {
                ViewName = "Modals/_RequesterPartial",
                ViewData = new ViewDataDictionary<List<requesterObj>>(ViewData, requesters)
            };
        }
       

        private async Task<(string, string, string, List<SelectListItem>)> GeneratePRNo(string userId)
        {

            //get staff object
            var user = await _procContext.Staffs.FirstOrDefaultAsync(m=>m.Id==userId);


            //get current user details from staff table. From the fucking staff table
            var staff = await _bsslContext.Useracct.FirstOrDefaultAsync(x => x.Userid == user.StaffCode);

            if (staff == null) throw new Exception("Staff Not Setup");
            //get company prefix 
            var companyCode = staff.Compcode;
            var comp = _bsslContext.Compdata.FirstOrDefault(m => m.Compcode == companyCode);

            if (comp == null) throw new Exception("No Company Prefix found");

            var compPrefix = comp.Names;

            var deptCode = _bsslContext.Stafftab.FirstOrDefault(st => st.Staffid == staff.Userid).Deptcode;
            


            var Depts = _bsslContext.Codestab.Where(opt => opt.Option1 == "F5");

            var Dept = Depts.FirstOrDefault(cd => cd.Code == deptCode);

            var DeptPrefix = Dept.Prefixcode;

            var year = DateTime.Now.Year.ToString();

            //implement serial no
            var lastRequisition = _procContext.Requisitions.OrderByDescending(t => t.PRNumber).FirstOrDefault();

            var serialNo = "";

            if (lastRequisition == null)
            {
                serialNo = "00001";
            }
            else
            {
                var num = (Convert.ToInt32(lastRequisition.PRNumber.Split('/').Last()) + 1);
                serialNo = num.ToString("00000");
            }

           // serialNo = PrNo == null ? "00001" : (Convert.ToInt32(lastRequisition.PRNumber) + 1).ToString("00000");

            //itf/deptcode/deptprefix/year/serial no

            return ($"{compPrefix.Trim()}/{deptCode.Trim()}/{DeptPrefix.Trim()}/{year}/{serialNo}", deptCode, Dept.Desc1, Depts.Select(depts => new SelectListItem { Text = depts.Desc1 }).ToList());


        }

        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

    }
}