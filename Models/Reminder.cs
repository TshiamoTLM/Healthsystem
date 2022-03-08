using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace healthsystem.Models
{
    public class Reminder
    {
        [Key]
        [BindNever]
        public int Id { get; set; }
        public string userId { get; set; }
        [Required]
        [Display(Name = "Details")]
        public string Details { get; set; }

        public int ConsultationId { get; set; }


        public virtual Consultation Consultation { get; set; }
    }
}
