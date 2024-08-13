using System;

using Microsoft.EntityFrameworkCore;
namespace BookStoreManagement.Domain.Context;



    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options)
            : base(options)
        {
        }

    public BaseDbContext(DbContextOptions options) : base(options)
    {
    }

    // Common configurations or methods for derived contexts
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply common configurations here
            // For example, setting default values or global filters
        }

        // You can add common DbSets if needed, for example:
        // public DbSet<SomeCommonEntity> SomeCommonEntities { get; set; }
    }

