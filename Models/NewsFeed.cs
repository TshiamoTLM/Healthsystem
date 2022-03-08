using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace healthsystem.Models
{
    public class NewsFeed
    {
        [Key]
        [BindNever]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required, Display(Name = "Details")]
        public string Description { get; set; }
        public DateTime PostDate { get; set; }
    }
}
