using E_Commerce_API.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
    }
}
