using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class TaskDbContext : DbContext
    {
        public DbSet<User> Users {get; set;}
        public DbSet<Comment> Comments {get; set;}
        public DbSet<Task> Tasks {get; set;}
        public DbSet<StatusChange> StatusChanges {get; set;}

        public TaskDbContext(DbContextOptions options) : base(options)
        {}

    }
}