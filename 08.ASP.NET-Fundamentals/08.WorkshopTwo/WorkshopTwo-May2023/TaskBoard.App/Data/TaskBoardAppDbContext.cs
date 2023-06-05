namespace TaskBoard.App.Data;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Models;
using Task = Models.Task;

public class TaskBoardAppDbContext : IdentityDbContext<IdentityUser>
{
    private IdentityUser TestUser { get; set; }
    private Board OpenBoard { get; set; }
    private Board InProgressBoard { get; set; }
    private Board DoneBoard { get; set; }

    public TaskBoardAppDbContext(DbContextOptions<TaskBoardAppDbContext> options)
        : base(options)
    {
        this.Database.Migrate();
    }

    public DbSet<Task> Tasks { get; set; }
    public DbSet<Board> Boards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Task>()
            .HasOne(t => t.Board)
            .WithMany(b => b.Tasks)
            .HasForeignKey(t => t.BoardId)
            .OnDelete(DeleteBehavior.Restrict);

        SeedUsers();
        modelBuilder
            .Entity<IdentityUser>()
            .HasData(TestUser);

        SeedBoards();
        modelBuilder
            .Entity<Board>()
            .HasData(OpenBoard, InProgressBoard, DoneBoard);

        modelBuilder
            .Entity<Task>()
            .HasData(new Task()
            {
                Title = "Improve CSS styles",
                Description = "Implement better styling for all public pages",
                CreatedOn = DateTime.Now.AddDays(-200),
                OwnerId = TestUser.Id,
                BoardId = OpenBoard.Id
            },
            new Task()
            {
                Title = "Android Client App",
                Description = "Create Android client app for the TaskBoard RESTful API",
                CreatedOn = DateTime.Now.AddDays(-5),
                OwnerId = TestUser.Id,
                BoardId = OpenBoard.Id
            },
            new Task()
            {
                Title = "Desktop Client App",
                Description = "Create Windows Forms desktop app client for the TaskBoard RESTful API",
                CreatedOn = DateTime.Now.AddDays(-1),
                OwnerId = TestUser.Id,
                BoardId = InProgressBoard.Id
            },
            new Task()
            {
                Title = "Create Tasks",
                Description = "Implement [Create Task] page for adding new tasks",
                CreatedOn = DateTime.Now.AddYears(-1),
                OwnerId = TestUser.Id,
                BoardId = DoneBoard.Id
            });

        base.OnModelCreating(modelBuilder);
    }

    private void SeedUsers()
    {
        var hasher = new PasswordHasher<IdentityUser>();

        TestUser = new IdentityUser()
        {
            Id = "test-user-id-guid",
            UserName = "test@softuni.bg",
            NormalizedUserName = "TEST@SOFTUNI.BG"
        };

        TestUser.PasswordHash = hasher.HashPassword(TestUser, "softuni");
    }
    private void SeedBoards()
    {
        OpenBoard = new Board()
        {
            Id = 1,
            Name = "Open"
        };

        InProgressBoard = new Board()
        {
            Id = 2,
            Name = "In Progress"
        };

        DoneBoard = new Board()
        {
            Id = 3,
            Name = "Done"
        };
    }
}