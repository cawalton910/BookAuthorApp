using BookAuthorApp.Models.Entities;
using BookAuthorApp.Models.ViewModels;
using BookAuthorApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookAuthorApp.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IBookRepository _bookRepository;
        public AuthorController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CreateAsync([Bind(Prefix = "id")]int bookId)
        {
            var book = await _bookRepository.ReadAsync(bookId);
            if (book == null)
            {
                RedirectToAction("Index", "Book");
            }
            ViewData["Book"] = book;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int bookId, CreateAuthorVM author)
        {
            if (author != null)
            {
                var model = author.GetAuthorInstance();
                await _bookRepository.CreateAuthorAsync(bookId, model);
                return RedirectToAction("Details", "Book", new {id = bookId});
            }
            var book = _bookRepository.ReadAsync(bookId);
            ViewData["Book"] = book;
            return View(author);
        }
    }
}
