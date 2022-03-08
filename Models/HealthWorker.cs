using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace healthsystem.Models
{
    public class HealthWorker
    {
        [Key]
        [BindNever]
        public int HealthWorkerId { get; set; }
        [Required]
        [Display(Name = "Worker Name")]
        public string Name { get; set; }
        [Display(Name = "Worker Type")]
        public int WorkerTypeId { get; set; }
        public virtual WorkerType WorkerType { get; set; }
    }
}
