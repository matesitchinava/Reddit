using Microsoft.EntityFrameworkCore;
using Reddit.Entities;
using System.Collections.Generic;

namespace Reddit
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Community> Communities { get; set; }
        
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Vote> Vote { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the DbContext to use an In-Memory database
            optionsBuilder.UseInMemoryDatabase("RedditDb");
        }
    }
}
