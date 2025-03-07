using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ToDoWeb.Models
{
    public class ToDoTasksDbContext : DbContext
    {
        public DbSet<ToDoTask> Tasks {  get; set; }

        public ToDoTasksDbContext(DbContextOptions<ToDoTasksDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoTask>()
                .HasKey(t => t.Heading);  // Define the primary key
                                     // Other configurations
        }
    }
}
