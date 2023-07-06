using Forum.API.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Forum.API.Data
{
	public class ForumDbContext : IdentityDbContext<User>
	{
		public ForumDbContext(DbContextOptions<ForumDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>().Property(u => u.SocialLinks)
				.HasConversion(
					v => JsonConvert.SerializeObject(v),
					v => JsonConvert.DeserializeObject<List<SocialLink>>(v));

			// Seeding roles

			var adminRoleId = "72eca219-ce47-44cc-95f1-73ad2a5181d8";
			var posterRoleId = "9c72e413-7f5f-4e71-8bbe-415d3a58a340";

			var roles = new List<IdentityRole>()
			{
				new IdentityRole()
				{
					Id = adminRoleId,
					Name = "Admin",
					NormalizedName = "ADMIN",
					ConcurrencyStamp = adminRoleId
				},
				new IdentityRole()
				{
					Id = posterRoleId,
					Name = "Poster",
					NormalizedName = "POSTER",
					ConcurrencyStamp = posterRoleId
				},
			};

			modelBuilder.Entity<IdentityRole>().HasData(roles);

			// Seeding users

			var users = new List<User>()
			{
				new User() {
					Id = "483b5d6e-6098-4392-ac76-37a9c76d4561",
					Email="admin@forum.com",
					NormalizedEmail = "admin@forum.com".ToUpper(),
					UserName="admin",
					NormalizedUserName="ADMIN",
				},
				new User() {
					Id = "8bd0b433-3eb3-4c51-9ef6-23323e0ec16c",
					Email = "poster@forum.com",
					NormalizedEmail = "poster@forum.com".ToUpper(),
					UserName = "poster",
					NormalizedUserName = "POSTER",
				}
			};

			PasswordHasher<User> ph = new();
			users[0].PasswordHash = ph.HashPassword(user: users[0], "admin");
			users[1].PasswordHash = ph.HashPassword(user: users[1], "poster");

			modelBuilder.Entity<User>().HasData(users);

			var roleUsers = new List<IdentityUserRole<string>>()
			{
				new IdentityUserRole<string>()
				{
					RoleId = adminRoleId,
					UserId = users[0].Id,
				},
				new IdentityUserRole<string>()
				{
					RoleId = posterRoleId,
					UserId = users[1].Id,
				}
			};

			modelBuilder.Entity<IdentityUserRole<string>>().HasData(roleUsers);

			modelBuilder.Entity<User>()
				.Ignore(c => c.AccessFailedCount)
				.Ignore(c => c.LockoutEnabled)
				.Ignore(c => c.LockoutEnd)
				.Ignore(c => c.TwoFactorEnabled)
				.Ignore(c => c.PhoneNumber)
				.Ignore(c => c.PhoneNumberConfirmed)
				.Ignore(c => c.AccessFailedCount)
				.Ignore(c => c.EmailConfirmed);
		}
	}
}