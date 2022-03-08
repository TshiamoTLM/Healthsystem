using Microsoft.EntityFrameworkCore;
using healthsystem.Models;
using System.Collections.Generic;

namespace healthsystem.Data
{
    public class EFReminderRepository
    : RepositoryBase<Reminder>, IReminderRepository
    {
        public EFReminderRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }

        public IEnumerable<Reminder> FindWithDependencies()
        {
            return _appDbContext.Reminders
                .Include(s => s.Consultation);
        }
    }
}
