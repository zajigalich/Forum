using Forum.API.Models.Domain;

namespace Forum.API.Repositories
{
	public interface ITokenRepository
	{
		string CreateJwtToken(User user, List<string> roles);
	}
}
