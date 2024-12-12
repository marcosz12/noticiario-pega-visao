using Microsoft.EntityFrameworkCore;
using Noticiario.Data;
using Noticiario.Models;

namespace Noticiario.Services
{
    public class NewService
    {
        private readonly NewsContext _context;
        public NewService(NewsContext context)
        {
            _context = context;
        }

        public async Task<List<New>> FindAllAsync()
        {
            return await _context.News.ToListAsync();
        }

        public async Task InsertAsync(New news)
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
    }
}
