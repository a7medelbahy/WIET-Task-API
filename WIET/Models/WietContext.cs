using Microsoft.EntityFrameworkCore;

namespace WIET.Models
{
    public class WietContext:DbContext
    {
        public WietContext()
        {   
        }
        public WietContext(DbContextOptions options):base(options) { }
        
        public DbSet<Employee> Employees { get; set; }
    }
}
