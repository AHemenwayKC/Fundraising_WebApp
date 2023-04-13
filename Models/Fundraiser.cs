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
        public List<Fundraiser>? Fundraisers { get; set; }
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
        public List<Donation>? Donations { get; set; }
    }
    public class Donation
    {
        public int Id { get; set; }
        [Display(Name = "Donation Amount")]
        public int amount { get; set; }
        [Display(Name = "Donation Date")]
        [DataType(DataType.Date)]
        public DateTime donateDate { get; set; }
        [Display(Name = "User Name")]
        public string? userName { get; set; }
        [Display(Name = "Card Number")]
        public string? cardNum { get; set; }
        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        public DateTime expirationDate { get; set; }
        [Display(Name = "CVV")]
        public int CVV { get; set; }
        [Display(Name = "Name on Card")]
        public string? fullName { get; set; }
        [Display(Name = "Zip Code")]
        public int zipCode { get; set; }
        [Display(Name = "Fundraiser ID")]
        public int fundraiserId { get; set; }
    }
}

