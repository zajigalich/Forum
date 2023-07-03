﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.API.Models.Domain
{
	public class User
	{
        public int Id { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public string Password { get; set; }

		[MaxLength(50)]
		public string DisplayName { get; set; }

        public DateOnly? BirthDate { get; set; }

		[MaxLength(200)]
		public string? About { get; set; }

        public bool Deactivated { get; set; } = false;

		[NotMapped]
        public IFormFile? Image { get; set; }
        public string? ImagePath { get; set; }

        public List<SocialLink> SocialLinks { get; set; } // would be serialized


    }
}
