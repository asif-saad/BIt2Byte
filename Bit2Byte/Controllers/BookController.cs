using Bit2Byte.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bit2Byte.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(BookRepository bookRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _webHostEnvironment = webHostEnvironment;

        }







        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }













        [Route("achievement-details/{id}", Name = "AchievementDetailsRoute")]
        public async Task<ViewResult> GetBook(int id, string NameofBook)
        {
            var data = await _bookRepository.GetBookById(id);
            //dynamic data = new System.Dynamic.ExpandoObject();
            //data.book = _bookRepository.GetBookById(id);
            //data.Name = "test";

            return View(data);
            //return View(_bookRepository.GetBookById(id));

            //return _bookRepository.GetBookById(id);
        }











        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }












        public ViewResult AddNewAchievement(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }



        // we can return anyview with IActionResult
        [HttpPost]
        public async Task<IActionResult> AddNewAchievement(BookModel bookmodel)
        {
            //_bookRepository.AddNewAchievement(bookmodel);

            if (ModelState.IsValid)
            {

            }

            if (bookmodel.CoverPhoto != null)
            {
                string folder = "books/cover/";
                bookmodel.CoverImageUrl = await UploadImage(folder, bookmodel.CoverPhoto);
            }


            if (bookmodel.GalleryFiles != null)
            {
                string folder = "books/gallery/";
                bookmodel.Gallery = new List<GalleryModel>();

                foreach (var file in bookmodel.GalleryFiles)
                {
                    var gallery = new GalleryModel()
                    {
                        Name = file.Name,
                        URL = await UploadImage(folder, file)
                    };
                    bookmodel.Gallery.Add(gallery);


                    //await UploadImage(folder, file);
                }
            }

            int id = await _bookRepository.AddNewAchievement(bookmodel);
            if (id > 0)
            {

                return RedirectToAction(nameof(AddNewAchievement), new { isSuccess = true, bookId = 1 });
            }



            return View();

        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            //string folder = "books/cover/";
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;



            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "/" + folderPath;
        }
    }
}
