using healthsystem.Models;
using System.Collections.Generic;

namespace healthsystem.Data
{
    public interface IReminderRepository : IRepositoryBase<Reminder>
    {
        public IEnumerable<Reminder> FindWithDependencies();
    }
}
