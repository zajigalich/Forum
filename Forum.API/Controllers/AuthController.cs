using AutoMapper;
using Forum.API.Models.Domain;
using Forum.API.Models.DTO;
using Forum.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Forum.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IUserRepository userRepository;
		private readonly ITokenRepository tokenRepository;
		private readonly IMapper mapper;

		public AuthController(IUserRepository userRepository, ITokenRepository tokenRepository, IMapper mapper)
		{
			this.userRepository=userRepository;
			this.tokenRepository=tokenRepository;
			this.mapper=mapper;
		}

		// CREATE USER
		// POST: /api/auth/register
		[HttpPost]
		[Route("Register")]
		public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
		{
			var userDomainModel = mapper.Map<User>(registerRequestDto);

			var user = await userRepository.CreateAsync(userDomainModel);

			if (user != null)
			{
				return Ok("User was registered! Please login.");

			}

			return BadRequest("Something went wrong");
		}

		// LOGIN USER
		// POST: /api/auth/login
		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
		{
			var user = await userRepository.FindByEmailAsync(loginRequestDto.Email);

			if (user != null && (user.Password == loginRequestDto.Password))
			{
				var roles = user.Roles.Select(r => r.Name);

				if (roles != null)
				{
					// CreateToken*/

					var jwtToken = tokenRepository.CreateJwtToken(user, roles.ToList());

					var loginResponce = new LoginResponceDto()
					{
						JwtToken = jwtToken
					};

					return Ok(loginResponce);

				}
			}

			return BadRequest("Username or password incorrect");
		}
	}
}
