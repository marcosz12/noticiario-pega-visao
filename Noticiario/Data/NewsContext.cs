using Noticiario.Models.ViewModels;
using Microsoft.EntityFrameworkCore;


namespace Noticiario.Data
{
    public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> options) : base(options)
        {

        }
        public DbSet<New> News { get; set; }
    }
}
