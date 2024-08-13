using System;

using Microsoft.EntityFrameworkCore;
namespace BookStoreManagement.Domain.Context;



      public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply common configurations here
        }
    }

