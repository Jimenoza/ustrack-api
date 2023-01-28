using System;
using Microsoft.EntityFrameworkCore;

namespace ustrack_api.Models
{
	public class UserContext : DbContext
	{
        public UserContext(DbContextOptions<UserContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}

