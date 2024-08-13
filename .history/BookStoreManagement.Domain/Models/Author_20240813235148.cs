using System;

namespace BookStoreManagement.Domain.Models;
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }

        // Navigation property
        public ICollection<Book> Books { get; set; }
    }
}
