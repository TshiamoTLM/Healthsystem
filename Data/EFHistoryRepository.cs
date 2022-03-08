using healthsystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace healthsystem.Data
{
    public class EFHistoryRepository
    : RepositoryBase<History>, IHistoryRepository
    {
        public EFHistoryRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }
    }
}
