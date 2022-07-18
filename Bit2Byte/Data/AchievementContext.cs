using Microsoft.EntityFrameworkCore;

namespace Bit2Byte.Data
{
    public class AchievementContext : DbContext
    {
        public AchievementContext(DbContextOptions<AchievementContext> options)
            : base(options)
        {

        }


        public DbSet<Achievement> Achievements { get; set; }


    }
}
