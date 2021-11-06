using System;
using Microsoft.EntityFrameworkCore;
using Wsei.Lab7.Entities;

namespace Wsei.Lab7.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }

        public AppDbContext(DbContextOptions options):base(options)
        {

        }
    }
}
