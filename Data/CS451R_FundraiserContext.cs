using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CS451R_Fundraiser.Models;

namespace CS451R_Fundraiser.Data
{
    public class CS451R_FundraiserContext : DbContext
    {
        public CS451R_FundraiserContext (DbContextOptions<CS451R_FundraiserContext> options)
            : base(options)
        {
        }

        public DbSet<CS451R_Fundraiser.Models.Fundraiser> Fundraiser { get; set; } = default!;
    }
}
