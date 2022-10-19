using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BookAuthorApp.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public String? Title { get; set; }
        public int PublicationYear { get; set; }

        public ICollection<Author> Authors { get; set; }
            = new List<Author>();
    }
}
