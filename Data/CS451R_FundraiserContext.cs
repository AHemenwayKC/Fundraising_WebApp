using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CS451R_Fundraiser.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CS451R_Fundraiser.Data
{
    public class CS451R_FundraiserContext : IdentityDbContext
    {
        public CS451R_FundraiserContext (DbContextOptions<CS451R_FundraiserContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<User> User { get; set; } = default!;
        public DbSet<Fundraiser> Fundraiser { get; set; } = default!;
        public DbSet<Donation> Donation { get; set; } = default!;

    }
}
