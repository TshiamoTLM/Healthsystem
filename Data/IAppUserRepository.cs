using healthsystem.Models;

namespace healthsystem.Data
{
    public interface IAppUserRepository : IRepositoryBase<AppUser>
    {
        public AppUser GetByEmail(string Email);
    }
}
