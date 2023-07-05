using Forum.API.Models.Domain;

namespace Forum.API.Repositories
{
	public interface IUserRepository
	{
		Task<User?> CreateAsync(User user);
		Task<User?> FindByEmailAsync(string email);
	}
}