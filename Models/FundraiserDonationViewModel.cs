using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CS451R_Fundraiser.Models;

public class FundraiserDonationViewModel
{
    public Fundraiser? Fundraiser { get; set; }
    public List<Donation>? Donations { get; set; }
}