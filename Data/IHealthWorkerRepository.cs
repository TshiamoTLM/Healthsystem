
using healthsystem.Models;
using System.Collections.Generic;

namespace healthsystem.Data
{
    public interface IHealthWorkerRepository: IRepositoryBase<HealthWorker>
    {
        public IEnumerable<HealthWorker> FindWithDependencies();
    }
}