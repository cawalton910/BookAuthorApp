using BookAuthorApp.Models.Entities;
using BookAuthorApp.Models.ViewModels;
using BookAuthorApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookAuthorApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IActionResult> Index()
        {
            var allBooks = await _bookRepository.ReadAllAsync();
            var model = allBooks.Select(b =>
            new BookDetailsVM
            {
                Id = b.Id,
                Title = b.Title,
                PublicationYear = b.PublicationYear,
                NumberOfAuthors = b.Authors.Count
            });
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookVM book)
        {
            if (book != null)
            {
                var model = book.getBookInstance();
                await _bookRepository.CreateAsync(model);
                return RedirectToAction("Index");
            }
            return View(book);
        }
        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookRepository.ReadAsync(id);
            if(book == null)
            {
                return RedirectToAction("Index", "Book");
            }
            var model = new BookDetailsVM()
            {
                Id = book.Id,
                Title = book.Title,
                PublicationYear = book.PublicationYear
            };
            return View(model);
        }
    }
}
