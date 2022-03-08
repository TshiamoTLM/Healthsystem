using healthsystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace healthsystem.Data
{
    public class EFPatientTypeRepository
     : RepositoryBase<PatientType>, IPatientTypeRepository
    {
        public EFPatientTypeRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }
    }
}
