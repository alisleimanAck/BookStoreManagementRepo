using System;
using Microsoft.AspNetCore.Authentication;

namespace BookStoreManagement.Domain.Context;



    public class BookStoreDBContext : BaseDbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Entity-specific configurations
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);
            
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Publishers)
                .WithMany(p => p.Books)
                .UsingEntity(bp => bp.ToTable("BookPublishers"));
        }
    }


