using Microsoft.EntityFrameworkCore;
using SimpleEmployeeApp.Models;

namespace SimpleEmployeeApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        public DbSet<Employee> Employees { get; set; } = null!;
    }
}
