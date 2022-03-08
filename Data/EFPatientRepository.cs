using Microsoft.EntityFrameworkCore;
using healthsystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace healthsystem.Data
{
    public class EFPatientRepository
    : RepositoryBase<Patient>, IPatientRepository
    {
        public EFPatientRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
            
        }

        public IEnumerable<Patient> FindWithDependencies()
        {
            return _appDbContext.Patients
                .Include(s => s.PatientType);

        }
    }
}
