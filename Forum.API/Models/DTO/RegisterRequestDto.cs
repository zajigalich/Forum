using System.ComponentModel.DataAnnotations;

namespace Forum.API.Models.DTO
{
	public class RegisterRequestDto
	{
		[Required]
		[DataType(DataType.EmailAddress)]
        public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
        public string DisplayName { get; set; }
    }
}
