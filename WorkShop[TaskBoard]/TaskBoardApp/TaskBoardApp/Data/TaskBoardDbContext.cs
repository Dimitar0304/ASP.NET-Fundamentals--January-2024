using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data.Models;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Data
{
    public class TaskBoardDbContext : IdentityDbContext
    {
        public IdentityUser TestUser { get; set; }= new IdentityUser();
        public Board OpenBoard { get; set; } = new Board();
        public Board InProgressBoard { get; set; } = new Board();
        public Board DoneBoard { get; set; }= new Board();
        public TaskBoardDbContext(DbContextOptions<TaskBoardDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Task>()
                .HasOne(t => t.Board)
                .WithMany(t => t.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            SeedUsers();
            builder.Entity<IdentityUser>()
                .HasData(TestUser);

            SeedBoards();
            builder.Entity<Board>()
                .HasData(InProgressBoard, DoneBoard, OpenBoard);

            builder.Entity<Task>()
                .HasData(SeedTasks());

            base.OnModelCreating(builder);
        }

        private Task[] SeedTasks()
        {
            return new Task[]{new Task()
            {
                Id = 1,
                Title = "Improve CSS style",
                Description = "Implement better styling for all public pages ",
                CreatedOn = DateTime.Now.AddDays(-200),
                OwnerId = TestUser.Id,
                BoardId = OpenBoard.Id
            },
                new Task()
                {
                    Id = 2,
                    Title = "Android Client App",
                    Description = "Create andorid client app for restfull api",
                    CreatedOn = DateTime.Now.AddMonths(-5),
                    OwnerId = TestUser.Id,
                    BoardId = OpenBoard.Id
                },
                new Task()
                {
                    Id = 3,
                    Title = "Desktop client app",
                    Description = "Create desktop client form app for TaskBoard Restful API",
                    CreatedOn = DateTime.Now.AddMonths(-1),
                    OwnerId = TestUser.Id,
                    BoardId = InProgressBoard.Id
                },
                new Task()
                {
                    Id = 4,
                    Title = "Create Task",
                    Description = "Implement [Create Task] page for adding a new tasks ",
                    CreatedOn = DateTime.Now.AddYears(-1),
                    OwnerId = TestUser.Id,
                    BoardId = DoneBoard.Id
                }
            };
         }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Board> Boards { get; set; }

        private void SeedBoards()
        {
            OpenBoard = new Board()
            {
                Id = 1,
                Name = "OpenBoard"
            };
            InProgressBoard = new Board()
            {
                Id = 2,
                Name = "InProgressBoard"
            };
            DoneBoard = new Board()
            {
                Id = 3,
                Name = "DoneBoard"
            };
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();
            var user = new IdentityUser()
            {
                UserName = "test@softuni.bg",
                NormalizedUserName = "TEST@SOFTUNI.BG"
            };

            TestUser.UserName = user.UserName;
            TestUser.PasswordHash = hasher.HashPassword(user, "softuni");
            TestUser.NormalizedUserName = user.NormalizedUserName;
        }
    }
}