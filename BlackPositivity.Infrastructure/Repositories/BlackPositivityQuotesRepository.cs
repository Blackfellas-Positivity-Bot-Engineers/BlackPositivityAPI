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

        public async Task<bool> ResetQuotes()
        {
            var quotes = await GetAllQuotes();
            foreach (var quote in quotes)
            {
                quote.hasBeenUsed = false;
                _context.Entry(quote).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<BlackPositivityQuote> FreshQuote()
        {
            var quotes = await FreshCheck();
            var fresh = quotes.First(x => x.hasBeenUsed == false);
            fresh.hasBeenUsed = true;
            var success = await UpdateQuote(fresh.ID, fresh);
            return fresh;
        }

        public async Task<BlackPositivityQuote[]> FreshCheck()
        {
            var quotes = await _context.BlackPositivityQuotes.ToArrayAsync();
            var freshBatch = false;
            foreach(var quote in quotes)
            {
                if (quote.hasBeenUsed == false)
                {
                    freshBatch = true;
                }
                else
                {
                    continue;
                }
            }
            if(freshBatch == false)
            {
                var success = await ResetQuotes();
                var freshQuotes = await GetAllQuotes();
                return freshQuotes.ToArray();
            }
            return quotes;
        }

        public async Task<BlackPositivityQuote> RandomQuote()
        {
            var rand = new Random();
            var quotes = await GetAllQuotes();
            var quotesArray = quotes.ToArray();
            var randomQuoteInt = rand.Next(quotesArray.Length);
            var randomQuote = quotesArray[randomQuoteInt];
            return randomQuote;
        }
    }
}
