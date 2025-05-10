using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Models;
using System.Runtime.InteropServices.ObjectiveC;

namespace SupermarketWEB.Data
{
    public class SumermarketContext : DbContext
    {
        internal readonly object Edit;

        public SumermarketContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<PayMode> PayModes { get; set; }
      
    }
    }

