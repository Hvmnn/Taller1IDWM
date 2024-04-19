using Taller1IDWM.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace Taller1IDWM.Src.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set;} = null!;
        
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}