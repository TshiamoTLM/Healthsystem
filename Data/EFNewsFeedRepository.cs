using healthsystem.Models;

namespace healthsystem.Data
{
    public class EFNewsFeedRepository
      : RepositoryBase<NewsFeed>, INewsFeedRepository
    {
        public EFNewsFeedRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }
    }
}
