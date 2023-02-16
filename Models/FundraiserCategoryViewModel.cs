using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CS451R_Fundraiser.Models;

public class FundraiserCategoryViewModel
{
    public List<Fundraiser>? Fundraisers { get; set; }
    public SelectList? Categories { get; set; }
    public string? FundraiserCategory { get; set; }
    public string? SearchString { get; set; }
}