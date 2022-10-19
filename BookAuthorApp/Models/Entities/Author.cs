using System.ComponentModel.DataAnnotations;

namespace BookAuthorApp.Models.Entities
{
    public class Author
    {
        public int Id { get; set; }
        [StringLength(256)]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(128)]
        public string? LastName { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}
