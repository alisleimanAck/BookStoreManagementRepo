using System;

namespace BookStoreManagement.Domain.Models;
public class Author
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public  required string Biography { get; set; }

    // Navigation property
    public ICollection<Book> Books { get; set; }
}
