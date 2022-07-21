using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bit2Byte.Data
{
    public class AchievementContext : IdentityDbContext
    {
        public AchievementContext(DbContextOptions<AchievementContext> options)
            : base(options)
        {

        }


        public DbSet<Achievement> Achievements { get; set; }


        public DbSet<BookGallery> BookGallery { get; set; }


    }
}
