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
        public IActionResult Create([Bind(Prefix = "id")]int bookId)
        {
            var model = _bookRepository.ReadAsync(bookId);
            if (model == null)
            {
                RedirectToAction("Index", "Book");
            }
            ViewData["Book"] = model;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(int bookId, CreateAuthorVM author)
        {
            if (author != null)
            {
                var model = author.GetAuthorInstance();
                await _bookRepository.CreateAuthorAsync(bookId, model);
                return RedirectToAction("Index");
            }
            return View(author);
        }
    }
}
