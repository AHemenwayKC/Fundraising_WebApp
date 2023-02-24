using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS451R_Fundraiser.Models
{
    public class Fundraiser
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        [Display(Name = "Post Date")]
        [DataType(DataType.Date)]
        public DateTime PostDate { get; set; }
        public string? Category { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Goal { get; set; }
    }
    
    public class FundDBContext : DbContext
    {
        public FundDBContext()
        { }
        public DbSet<Fundraiser> Fundraisers { get; set; }
    }
}
