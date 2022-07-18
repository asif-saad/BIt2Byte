using Bit2Byte.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bit2Byte.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;

        }
        public async Task<ViewResult> GetAllBooks()
        {
            var data = _bookRepository.GetAllBooks();
            return View(data);
        }


        [Route("achievement-details/{id}", Name = "AchievementDetailsRoute")]
        public ViewResult GetBook(int id, string NameofBook)
        {
            //var data = _bookRepository.GetBookById(id);
            //return View(data);
            dynamic data = new System.Dynamic.ExpandoObject();
            data.book = _bookRepository.GetBookById(id);
            data.Name = "test";
            return View(data);
            //return View(_bookRepository.GetBookById(id));

            //return _bookRepository.GetBookById(id);
        }


        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }


        public ViewResult AddnewAchievement(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }

        // we can return anyview with IActionResult
        [HttpPost]
        public async Task<IActionResult> AddnewAchievement(BookModel bookmodel)
        {
            //_bookRepository.AddNewAchievement(bookmodel);


            int id = await _bookRepository.AddNewAchievement(bookmodel);
            if (id > 0)
            {
                return RedirectToAction(nameof(AddnewAchievement), new { isSuccess = true });
            }
            return View();

        }
    }
}
