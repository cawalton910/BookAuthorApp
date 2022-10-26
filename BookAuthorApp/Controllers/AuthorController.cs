using BookAuthorApp.Models.Entities;
using BookAuthorApp.Models.ViewModels;
using BookAuthorApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
        public async Task<IActionResult> CreateAsync([Bind(Prefix = "id")] int bookId)
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
                return RedirectToAction("Details", "Book", new { id = bookId });
            }
            var book = _bookRepository.ReadAsync(bookId);
            ViewData["Book"] = book;
            return View(author);
        }
        public async Task<IActionResult> Edit([Bind(Prefix = "id")] int bookId, int authorId)
        {
            var book = await _bookRepository.ReadAsync(bookId);
            if (book == null)
            {
                return RedirectToAction("Index", "Book");
            }
            var author = book.Authors.FirstOrDefault(a => a.Id == authorId);
            if (author == null )
            {
                return RedirectToAction("Details", "Book");
            }
            var model = new EditAuthorVM()
            {
                Book = book,
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName
            };
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int bookId, EditAuthorVM authorVM)
        {
            if (ModelState.IsValid)
            {
                var author = authorVM.GetAuthorInstance();
                await _bookRepository.UpdateAuthorAsync(bookId, author);
                return RedirectToAction("Details", "Book", new { id = bookId});
            }
            authorVM.Book = await _bookRepository.ReadAsync(bookId);
            return View(authorVM);
        }

        public async Task<IActionResult> Delete([Bind(Prefix = "id")]int bookId, int authorId)
        {
            var book = await _bookRepository.ReadAsync(bookId);
            if(book == null)
            {
                return RedirectToAction("Index", "Book");
            }
            var author = book.Authors.FirstOrDefault(a => a.Id == authorId);
            if (author == null)
            {
                return RedirectToAction("Details", "Book", new { id = bookId });
            }
            var model = new DeleteAuthorVM()
            {
                Book = book,
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName
            };
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int bookId, int authorId)
        {
            await _bookRepository.DeleteAuthorAsync(bookId, authorId);
            return RedirectToAction("Details", "Book", new { id = bookId });
        }
    }
}
