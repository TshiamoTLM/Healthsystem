using healthsystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace healthsystem.Data
{
    public class EFWorkerTypeRepository
     : RepositoryBase<WorkerType>, IWorkerTypeRepository
    {
        public EFWorkerTypeRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }
    }
}
