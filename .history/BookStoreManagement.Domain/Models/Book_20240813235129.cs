using System;

namespace BookStoreManagement.Domain.Models;

  public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
        public int AuthorId { get; set; }

        // Navigation properties
        public Author Author { get; set; }
        public ICollection<Publisher> Publishers { get; set; }
    }
