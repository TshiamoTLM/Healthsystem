using healthsystem.Models;

namespace healthsystem.Data
{
    public class EFAppUserRepository
     : RepositoryBase<AppUser>, IAppUserRepository
    {
        public EFAppUserRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }

        public AppUser GetByEmail(string Email)
        {
            var users = _appDbContext.Users;
            AppUser user = null;
            foreach (var item in users)
            {
                if(item.Email == Email)
                    user = item;
            }

            return user;
        }
    }
}

