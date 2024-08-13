using System;

namespace BookStoreManagement.Domain.Models;

    public class Publisher
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }

        // Navigation property
        public required ICollection<Book> Books { get; set; }
    }

