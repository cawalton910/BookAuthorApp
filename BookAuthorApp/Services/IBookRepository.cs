using BookAuthorApp.Models.Entities;

namespace BookAuthorApp.Services
{
    public interface IBookRepository
    {
        Task<ICollection<Book>> ReadAllAsync();
        Task<Book> CreateAsync(Book book);
        Task<Book?> ReadAsync(int id);
        Task<Author> CreateAuthorAsync(int bookId, Author author);
        Task UpdateAuthorAsync(int bookId, Author UpdatedAuthor);  
        Task DeleteAuthorAsync(int bookId, int authorId);
    }
}
