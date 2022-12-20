using Microsoft.EntityFrameworkCore;
using WebAPI_Task.Models;

namespace WebAPI_Task.Data
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options) 
        { 
            ////
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Models.Task> Tasks{ get; set; }
    }
}
