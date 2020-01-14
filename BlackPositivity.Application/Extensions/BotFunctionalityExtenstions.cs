using System.Linq;
using BlackPositivity.Domain.Models;

namespace BlackPositivity.Application.Extensions
{
    public static class BotFunctionalityExtenstions
    {
        public static BlackPositivityQuote[] GetUnusedQuotes(
            BlackPositivityQuote[] quotesArray)
        {
            var array = quotesArray;
            quotesArray = (from q in array
                               where q.hasBeenUsed == false
                               select new BlackPositivityQuote
                               {
                                   ID = q.ID,
                                   Quote = q.Quote,
                                   hasBeenUsed = q.hasBeenUsed,
                                   DateAdded = q.DateAdded,
                                   Contributor = q.Contributor
                               }).ToArray();

            return quotesArray;
        }
    }
}