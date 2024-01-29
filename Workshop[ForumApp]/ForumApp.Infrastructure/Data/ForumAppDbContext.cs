using ForumApp.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.Infrastructure.Data
{
    public class ForumAppDbContext: DbContext
    {
        private Post FirstPost { get;set; }
        private Post SecondPost { get;set; }
        private Post ThirdPost { get;set; }


        public ForumAppDbContext(DbContextOptions<ForumAppDbContext>options):base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedPost();
            modelBuilder.Entity<Post>()
                .HasData(FirstPost, SecondPost, ThirdPost);
            base.OnModelCreating(modelBuilder);
        }

        private void SeedPost()
        {
            FirstPost = new Post()
            {
                Id = 1,
                Title = "My first post",
                Content = "My first post will be for CRUD operations in MVC.It's so much fun!"
                
            };
            SecondPost = new Post()
            {
                Id=2,
                Title = "My second post",
                Content = "This is my second post in this MVC app and It's more creatifully"

            };
            ThirdPost = new Post()
            { 
                Id=3,
                Title = "My third post",
                Content = "Hello with my third post in this platform I hope to become a better in writing post!"

            };
        }

        public DbSet<Post> Posts { get; set; } = null!;
    }
}
