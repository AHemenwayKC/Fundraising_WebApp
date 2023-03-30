// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using System;
using System.Threading.Tasks;
using CS451R_Fundraiser.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CS451R_Fundraiser.Areas.Identity.Pages.Account.Manage
{
    public class MyFundraisersModel : PageModel
    {
        private readonly UserManager<CS451R_Fundraiser.Models.User> _userManager;
        private readonly ILogger<PersonalDataModel> _logger;
        private readonly CS451R_FundraiserContext _context;

        public MyFundraisersModel(
            UserManager<CS451R_Fundraiser.Models.User> userManager,
            ILogger<PersonalDataModel> logger,
            CS451R_FundraiserContext context)
        {
            _userManager = userManager;
            _logger = logger;
            _context = context;
        }
    }
}
