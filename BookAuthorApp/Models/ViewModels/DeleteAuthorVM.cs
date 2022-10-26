using BookAuthorApp.Models.Entities;

namespace BookAuthorApp.Models.ViewModels
{
    public class DeleteAuthorVM
    {
        public Book? Book { get; set; }
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

    }
}
