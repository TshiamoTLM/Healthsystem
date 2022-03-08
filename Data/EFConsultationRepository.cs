using healthsystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace healthsystem.Data
{
    public class EFConsultationRepository
      : RepositoryBase<Consultation>, IConsultationRepository
    {
        public EFConsultationRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }
    }
}
