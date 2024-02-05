using Microsoft.EntityFrameworkCore;
using ToDoListTestApp.Entity;

namespace ToDoListTestApp.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<AppUser> AppUsers => Set<AppUser>();
        public DbSet<ToDoList> ToDoLists => Set<ToDoList>();
        public DbSet<ToDoListTask> ToDoListTasks => Set<ToDoListTask>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
} 
