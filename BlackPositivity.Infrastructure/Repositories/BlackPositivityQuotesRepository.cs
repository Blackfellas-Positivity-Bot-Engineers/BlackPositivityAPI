using BlackPositivity.Domain.Models;
using BlackPositivity.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackPositivity.Infrastructure.Repositories
{
    public class BlackPositivityQuotesRepository : IBlackPositivityQuotesRepository
    {
        private readonly ApplicationDbContext _context;
        public BlackPositivityQuotesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BlackPositivityQuote> CreateQuote(BlackPositivityQuote quote)
        {
            _context.BlackPositivityQuotes.Add(quote);
            await _context.SaveChangesAsync();

            return await this.GetQuote(quote.ID);
        }

        public async Task<BlackPositivityQuote> DeleteQuote(Guid id)
        {
            var blackPositivityQuote = await _context.BlackPositivityQuotes.FindAsync(id);
            _context.BlackPositivityQuotes.Remove(blackPositivityQuote);
            await _context.SaveChangesAsync();

            return blackPositivityQuote;
        }

        public async Task<IEnumerable<BlackPositivityQuote>> GetAllQuotes()
        {
            return await _context.BlackPositivityQuotes.ToListAsync();
        }

        public async Task<BlackPositivityQuote> GetQuote(Guid id)
        {
            var blackPositivityQuote = await _context.BlackPositivityQuotes.FindAsync(id);

            return blackPositivityQuote;
        }

        public bool QuoteExists(Guid id)
        {
            return _context.BlackPositivityQuotes.Any(e => e.ID == id);
        }

        public async Task<bool> UpdateQuote(Guid id, BlackPositivityQuote quote)
        {

            _context.Entry(quote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return false;
            }

            return true;

        }
    }
}
