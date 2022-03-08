using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace healthsystem.Models
{
    public class History
    {
        [Key]
        [BindNever]
        public int HistoryId { get; set; }
        [Required]
        [Display(Name = "History Details")]
        public string Descr { get; set; }

    }
}
