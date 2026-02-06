using Microsoft.EntityFrameworkCore;
using DotNetSqlJenkins.Models;

namespace DotNetSqlJenkins.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
