using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace healthsystem.Models
{
    public class Consultation
    {
        [Key]
        [BindNever]
        public int ConsultationId { get; set; }
        [Required]
        [Display(Name = "Constultation Date")]
        public DateTime Date { get; set; }
    }
}
