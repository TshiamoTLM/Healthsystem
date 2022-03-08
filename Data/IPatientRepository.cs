using healthsystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace healthsystem.Data
{
    public interface IPatientRepository: IRepositoryBase<Patient>
    {
        public IEnumerable<Patient> FindWithDependencies();

    }
}
