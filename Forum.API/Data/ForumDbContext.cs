﻿using Forum.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Forum.API.Data
{
	public class ForumDbContext : DbContext
	{
        public ForumDbContext(DbContextOptions<ForumDbContext> options) : base(options) 
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

	}
}