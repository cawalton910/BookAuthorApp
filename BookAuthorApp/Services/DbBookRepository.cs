using BookAuthorApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookAuthorApp.Services
{
    public class DbBookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _db;
        public DbBookRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Book> CreateAsync(Book book)
        {
            _db.Books.Add(book);
            await _db.SaveChangesAsync();
            return book;
        }

        public async Task<Author> CreateAuthorAsync(int bookId, Author author)
        {
            var book = await _db.Books.FindAsync(bookId);
            if(book != null && author != null)
            {
                book.Authors.Add(author);
                author.Book = book;
                _db.SaveChanges();
                return author;
            }
            return new Author();

        }

        public async Task<ICollection<Book>> ReadAllAsync()
        {
           return await _db.Books.ToListAsync();
        }

        public async Task<Book?> ReadAsync(int id)
        {
            return await _db.Books.FindAsync(id);
        }
    }
}
