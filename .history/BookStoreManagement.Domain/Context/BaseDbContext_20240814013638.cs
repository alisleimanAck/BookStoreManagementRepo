using System;

using Microsoft.EntityFrameworkCore;
namespace BookStoreManagement.Domain.Context;



      public class BaseDbContext<TContext> : DbContext where TContext : DbContext
    {
        public BaseDbContext(DbContextOptions<TContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply common configurations here
        }
    }

