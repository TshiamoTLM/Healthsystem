using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace healthsystem.Models
{
    public class PatientType
    {
        [Key]
        [BindNever]
        public int PatientTypeId { get; set; }
        [Required]
        [Display(Name = "Type Name")]
        public string TypeName { get; set; }
    }
}
