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
            var model = await ReadAsync(bookId);
            if(model != null && author != null)
            {
                
                model.Authors.Add(author);
                //author.Book = book;
                //author.BookId = bookId;
                
                await _db.SaveChangesAsync();
                return author;
            }
            return new Author();

        }

        public async Task<ICollection<Book>> ReadAllAsync()
        {
           return await _db.Books
                .Include(a => a.Authors)
                .ToListAsync();
        }

        public async Task<Book?> ReadAsync(int id)
        {
            var book = await _db.Books.FindAsync(id);
            if (book != null)
            {
                _db.Entry(book)
                    .Collection(a => a.Authors)
                    .Load();
            }
            return book;
        }
    }
}
