using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace healthsystem.Models
{
    public class AppUser : IdentityUser
    {
        public string IdNumber { get; set; }
        public string campusId { get; set; }
        public int PatientType { get; set; }
    }
}
