using Forum.API.Data;
using Forum.API.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Forum.API.Repositories
{
	public class SQLUserRepository : IUserRepository
	{
		private readonly ForumDbContext dbContext;

		public SQLUserRepository(ForumDbContext dbContext)
        {
			this.dbContext=dbContext;
		}

		public async Task<User?> CreateAsync(User user)
		{
			var posterRole = await dbContext.Roles.FirstOrDefaultAsync(r => r.Name == "Poster");

			if (posterRole != null)
			{
				user.Roles.Add(posterRole);

				await dbContext.Users.AddAsync(user);
				await dbContext.SaveChangesAsync();

				return user;
			}

			return null;
		}

		public async Task<User?> FindByEmailAsync(string email)
		{
			return await dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
		}

	}
}