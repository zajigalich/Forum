using Forum.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Forum.API.Data
{
	public class ForumDbContext : DbContext
	{
		public ForumDbContext(DbContextOptions<ForumDbContext> options) : base(options)
		{

		}

		public DbSet<User> Users { get; set; }

		public DbSet<Role> Roles { get; set; }

        public DbSet<RoleUser> RoleUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>().Property(u => u.SocialLinks)
				.HasConversion(
					v => JsonConvert.SerializeObject(v),
					v => JsonConvert.DeserializeObject<List<SocialLink>>(v));

			modelBuilder.Entity<User>()
				.HasMany(e => e.Roles)
				.WithMany(e => e.Users)
				.UsingEntity<RoleUser>();

			var roles = new List<Role>()
			{
				new Role() { Id = 1, Name = "Admin"},
				new Role() { Id = 2, Name = "Poster"},
			};

			modelBuilder.Entity<Role>().HasData(roles);

			var users = new List<User>()
			{
				new User() { 
					Id = 1, 
					Email="admin@forum.com", 
					Password="admin",
					DisplayName = "Admin",
				}
			};

			modelBuilder.Entity<User>().HasData(users);

			var roleUsers = new List<RoleUser>()
			{
				new RoleUser()
				{
					UserId = 1,
					RoleId = 1,
				}
			};

			modelBuilder.Entity<RoleUser>().HasData(roleUsers);
		}
	}
}