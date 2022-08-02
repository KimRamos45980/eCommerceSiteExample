using eCommerceSiteExample.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceSiteExample.Data
{
    public class VideoGameContext : DbContext
    {
        public VideoGameContext(DbContextOptions<VideoGameContext> option) : base(option)
        {

        }

        public DbSet<Game> Games { get; set; }
    }
}
