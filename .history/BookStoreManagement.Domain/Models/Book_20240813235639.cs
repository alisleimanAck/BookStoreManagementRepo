using System;

namespace BookStoreManagement.Domain.Models;

  public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
        public int AuthorId { get; set; }

        // Navigation properties
        public  required Author Author { get; set; }
        public ICollection<Publisher> Publishers { get; set; }
    }
