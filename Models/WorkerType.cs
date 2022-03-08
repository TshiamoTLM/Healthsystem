using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace healthsystem.Models
{
    public class WorkerType
    {
        [Key]
        [BindNever]
        public int WorkerTypeId { get; set; }
        [Required]
        [Display(Name = "Type Name")]
        public string TypeName { get; set; }
    }
}
