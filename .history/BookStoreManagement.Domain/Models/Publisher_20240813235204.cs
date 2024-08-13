using System;

namespace BookStoreManagement.Domain.Models;

    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        // Navigation property
        public ICollection<Book> Books { get; set; }
    }
}
