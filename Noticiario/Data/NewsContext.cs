using Microsoft.EntityFrameworkCore;
using Noticiario.Models;


namespace Noticiario.Data
{
    public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> options) : base(options)
        {

        }
        public DbSet<NewsItem> News { get; set; }
    }
}
