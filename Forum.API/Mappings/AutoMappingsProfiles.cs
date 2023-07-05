using AutoMapper;
using Forum.API.Models.Domain;
using Forum.API.Models.DTO;

namespace Forum.API.Mappings
{
	public class AutoMappingsProfiles : Profile
	{
		public AutoMappingsProfiles()
		{
			CreateMap<User, RegisterRequestDto>().ReverseMap();
		}
	}
}