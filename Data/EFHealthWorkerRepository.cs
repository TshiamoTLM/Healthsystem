using Microsoft.EntityFrameworkCore;
using healthsystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace healthsystem.Data
{
    public class EFHealthWorkerRepository
     : RepositoryBase<HealthWorker>, IHealthWorkerRepository
    {
        public EFHealthWorkerRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }

        public IEnumerable<HealthWorker> FindWithDependencies()
        {
            return _appDbContext.HealthWorkers.Include(
                s => s.WorkerType);
        }
    }
}
