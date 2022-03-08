using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace healthsystem.Models
{
    public class Patient
    {
        [Key]
        [BindNever]
        public int PatientId { get; set; }

        [Required]
        [Display(Name = "ID/Passport Number")]
        public string IdNumber { get; set; }
        [Display(Name = "Student/Staff Number")]
        public string campusID { get; set; }
        [Required]
        [Display(Name = "Cellphone Number")]
        public string Cellphone { get; set; }

        [Display(Name = "Medication Administrated")]
        public string Medication { get; set; }
        [Display(Name = "Diagonosis History")]
        public string Diagnosis { get; set; }

        [Display(Name = "Treatment Cost")]
        public string TreatmentCost { get; set; }
        public int PatientTypeId { get; set; }

        public virtual PatientType PatientType { get; set; }
      
      
    }
}
