using BookAuthorApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using BookAuthorApp.Models.ViewModels;

namespace BookAuthorApp.Services
{
    public class ApplicationDbContext : DbContext
    {
         public ApplicationDbContext(DbContextOptions options) : base(options)
         {
         }
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<BookAuthorApp.Models.ViewModels.BookDetailsVM> BookDetailsVM { get; set; }
        public DbSet<BookAuthorApp.Models.ViewModels.CreateBookVM> CreateBookVM { get; set; }
        public DbSet<BookAuthorApp.Models.ViewModels.CreateAuthorVM> CreateAuthorVM { get; set; }
    }
}
