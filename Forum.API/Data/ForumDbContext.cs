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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>().Property(u => u.SocialLinks)
				.HasConversion(
					v => JsonConvert.SerializeObject(v),
					v => JsonConvert.DeserializeObject<List<SocialLink>>(v));

		}
	}
}