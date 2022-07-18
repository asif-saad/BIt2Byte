using Bit2Byte.Data;
using Bit2Byte.Models;
using Microsoft.EntityFrameworkCore;

namespace Bit2Byte.Controllers
{
    public class BookRepository
    {
        private readonly AchievementContext _context = null;

        public BookRepository(AchievementContext context)
        {
            _context = context;
        }


        public async Task<int> AddNewAchievement(BookModel model)
        {
            var newAchievement = new Achievement()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                TotalPages = (int)model.TotalPages,
                UpdatedOn = DateTime.UtcNow,

            };


            _context.Achievements.AddAsync(newAchievement);
            await _context.SaveChangesAsync();


            return newAchievement.Id;




        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var achieves = new List<BookModel>();
            var allacheives = await _context.Achievements.ToListAsync();
            if (allacheives?.Any() == true)
            {
                foreach (var achieve in allacheives)
                {
                    achieves.Add(new BookModel()
                    {
                        Author = achieve.Author,
                        Category = achieve.Category,
                        Description = achieve.Description,
                        Id = achieve.Id,
                        Language = achieve.Language,
                        Title = achieve.Title,
                        TotalPages = achieve.TotalPages
                    });
                }
            }
            return achieves;
        }


        public BookModel GetBookById(int id) => DataSource().FirstOrDefault(x => x.Id == id);


        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) &&
            x.Author.Contains(authorName)).ToList();
        }






        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel()
                {
                    Id = 1,
                    Title = "Achievement at National hackathon",
                    Author = "Mr. X",
                    Description = "ver 2000 years old. Richard McClintock, a Latin professor" +
                " at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the " +
                "cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of 'de Finibus Bonorum" +
                " et Malorum' (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renai" +
                "ssance. The first line of Lorem Ipsum, 'Lorem ipsum dolor sit amet..', comes from ",
                    Language = "Bangladesh",
                    Category = "Mixed",
                    TotalPages = 1
                },






                new BookModel()
                {
                    Id = 1,
                    Title = "Achievement at National Girl hackathon",
                    Author = "Mr. Y",
                    Description = "words which don't look even slightly believable. If y" +
                "ou are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum g" +
                "enerators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a",
                    Language = "Bangladesh",
                    Category = "Women",
                    TotalPages = 2
                },







                new BookModel()
                {
                    Id = 1,
                    Title = "Achievement at HackMIT",
                    Author = "Mr. Z",
                    Description = "quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam vol" +
            "uptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro qui" +
            "squam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore mag" +
            "nam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commod" +
            "i consequatur? Quis autem vel eum iure reprehenderit qui in e",
                    Language = "US",
                    Category = "Mixed",
                    TotalPages = 5
                },






                new BookModel()
                {
                    Id = 1,
                    Title = "Achievement at HackZurich",
                    Author = "Mr. A",
                    Description = " consequences that are extremely painful. Nor again is there anyone" +
            " who loves or pursues or desires to obtain pain of itself, because it is pain, but because occasionally circumstances occur in which toil and pain can p" +
            "rocure him some great pleasure. To take a trivial example, which of us ever undertakes laborious physical exercise, except to obtain some advantage from" +
            " it? But who has any right to find fault with a man who chooses to enjoy a pleasure that has",
                    Language = "Switzerland",
                    Category = "Mixed",
                    TotalPages = 5
                }

            };
        }
    }
}