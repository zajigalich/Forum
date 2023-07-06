using Forum.API.Models.Domain;
using Forum.API.Models.DTO;
using Forum.API.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Forum.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly UserManager<User> userManager;
		private readonly ITokenRepository tokenRepository;

		public AuthController(UserManager<User> userManager, ITokenRepository tokenRepository)
		{
			this.userManager=userManager;
			this.tokenRepository=tokenRepository;
		}

		// CREATE USER
		// POST: /api/auth/register
		[HttpPost]
		[Route("Register")]
		public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
		{
			var identityUser = new User()
			{
				UserName = registerRequestDto.DisplayName,
				Email = registerRequestDto.Email
			};

			var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

			if (identityResult.Succeeded)
			{
				var posterRole = "Poster";

				identityResult = await userManager.AddToRoleAsync(identityUser, posterRole);

				if (identityResult.Succeeded)
				{
					return Ok("User was registered! Please login.");
				}
			}

			return BadRequest(identityResult);
		}

		// LOGIN USER
		// POST: /api/auth/login
		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
		{
			var user = await userManager.FindByEmailAsync(loginRequestDto.Email);

			if (user != null)
			{
				var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

				if (checkPasswordResult)
				{
					var roles = await userManager.GetRolesAsync(user);

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
			}

			return BadRequest("Username or password incorrect");
		}

	}
}
