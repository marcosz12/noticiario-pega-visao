using Microsoft.EntityFrameworkCore;
using Noticiario.Data;
using Noticiario.Models;
using Noticiario.Services.Exceptions;
using System.Data;

namespace Noticiario.Services
{
    public class NewService
    {
        private readonly NewsContext _context;
        public NewService(NewsContext context)
        {
            _context = context;
        }

        public async Task<List<NewsItem>> FindAllAsync()
        {
            return await _context.News.ToListAsync();
        }

        public async Task InsertAsync(NewsItem news)
        {
            _context.Add(news);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.News.FindAsync(id);
                _context.News.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new IntegrityExceptions(ex.Message);
            }
        }

        public async Task<NewsItem> FindByIdAsync(int id)
        {
            return await _context.News.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(NewsItem news)
        {
            bool hasAny = await _context.News.AnyAsync(x => x.Id == news.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                _context.Update(news);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }
    }
}
