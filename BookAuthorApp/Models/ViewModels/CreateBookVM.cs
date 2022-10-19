using BookAuthorApp.Models.Entities;
using System.ComponentModel;

namespace BookAuthorApp.Models.ViewModels
{
    public class CreateBookVM
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        [DisplayName("Publication Year")]
        public int PublicationYear { get; set; }
        public Book getBookInstance()
        {
            return new Book
            {
                Id = 0,
                Title = this.Title,
                PublicationYear = this.PublicationYear,
            };
        }
    }
}
