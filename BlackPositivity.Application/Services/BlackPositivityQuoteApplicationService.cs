using BlackPositivity.Application.Abstractions;
using BlackPositivity.Domain.Models;
using BlackPositivity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlackPositivity.Application.Services
{
    public class BlackPositivityQuoteApplicationService : IBlackPositivityQuoteApplicationService
    {
        private IBlackPositivityQuotesRepository _quotesRepo;
        public BlackPositivityQuoteApplicationService(IBlackPositivityQuotesRepository quotesRepo)
        {
            _quotesRepo = quotesRepo;
        }
        public async Task<BlackPositivityQuote> CreateQuote(BlackPositivityQuote quote)
        {
            var success = await _quotesRepo.CreateQuote(quote);
            return success;
        }

        public async Task<BlackPositivityQuote> DeleteQuote(Guid id)
        {
            var deletedQuote = await _quotesRepo.DeleteQuote(id);
            return deletedQuote;
        }

        public async Task<IEnumerable<BlackPositivityQuote>> GetAllQuotes()
        {
            var quotes = await _quotesRepo.GetAllQuotes();
            return quotes;
        }

        public async Task<BlackPositivityQuote> GetQuote(Guid id)
        {
            var quote = await _quotesRepo.GetQuote(id);
            return quote;
        }

        public bool QuoteExists(Guid id)
        {
            var exists =  _quotesRepo.QuoteExists(id);
            return exists;
        }

        public async Task<bool> UpdateQuote(Guid id, BlackPositivityQuote quote)
        {
            var success = await _quotesRepo.UpdateQuote(id, quote);
            return success;
        }
    }
}
