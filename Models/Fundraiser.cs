using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CS451R_Fundraiser.Models
{

    public class User : IdentityUser
    {
        //[Key]
        //public string? email { get; set; }
        //public string? name { get; set; }
        //public string? password { get; set; }
        //public string? card { get; set; }
        public List<Fundraiser> Fundraisers { get; set; }
    }
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
        public List<Donation> Donations { get; set; }
    }
    public class Donation
    {
        public int Id { get; set; }
        public int amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime donateDate { get; set; }
        public string? userName { get; set; }
        //public string? userEmail { get; set; }
        public int fundraiserId { get; set; }
    }
}

