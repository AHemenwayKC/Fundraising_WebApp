using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CS451R_Fundraiser.Models
{

    public class User
    {
        [Key]
        public string? email { get; set; }
        public string? name { get; set; }
        public string? password { get; set; }
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
    }
}

