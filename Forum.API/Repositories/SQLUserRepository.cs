using Forum.API.Data;

namespace Forum.API.Repositories
{
	public class SQLUserRepository : IUserRepository
	{
		private readonly ForumDbContext dbContext;

		public SQLUserRepository(ForumDbContext dbContext)
        {
			this.dbContext=dbContext;
		}

	}
}