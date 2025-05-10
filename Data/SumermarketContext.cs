using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Models;
using System.Runtime.InteropServices.ObjectiveC;

namespace SupermarketWEB.Data
{
    public class SumermarketContext : DbContext
    {
        public SumermarketContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public object categories { get; set; }
        public object  Product { get; set; }
    }
    }

