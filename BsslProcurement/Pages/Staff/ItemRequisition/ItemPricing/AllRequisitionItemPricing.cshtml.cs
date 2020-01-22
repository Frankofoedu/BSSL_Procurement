﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BsslProcurement.Interfaces;
using DcProcurement;
using DcProcurement.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BsslProcurement.Pages.Staff.ItemRequisition.ItemPricing
{
    [Authorize]
    public class AllRequisitionItemPricingModel : PageModel
    {
        private readonly ProcurementDBContext _context;
        private readonly IProcurementService _procurementService;
        private readonly UserManager<User> _userManager;
        public AllRequisitionItemPricingModel(ProcurementDBContext context, IProcurementService procurementService, UserManager<User> userManager)
        {
            _context = context;
            _procurementService = procurementService;
            _userManager = userManager;
            
        }


        public string Message { get; set; }
        public string Error { get; set; }



        [BindProperty]
        public List<Requisition> Requisitions { get; set; } = new List<Requisition>();
        public async Task OnGetAsync()
        {

            var user = await GetCurrentUserAsync();

            //get all requisitions that havent been priced
            Requisitions = await _procurementService.GetRequisitionsForPricingAssignedToUser(user.Id);
            
        }


        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}