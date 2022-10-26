using BookAuthorApp.Models.Entities;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace BookAuthorApp.Models.ViewModels
{
    public class EditAuthorVM
    {
        public Book? Book { get; set; }
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string? FirstName { get; set; }
        [DisplayName("Last Name")]
        public string? LastName { get; set; }
        public Author GetAuthorInstance()
        {
            return new Author
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
            };
        }
    }
}
