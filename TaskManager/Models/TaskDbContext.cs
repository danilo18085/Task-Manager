using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class TaskDbContext : DbContext
    {
        public DbSet<User> Users {get; set;}

        public TaskDbContext(DbContextOptions options) : base(options)
        {}

    }
}