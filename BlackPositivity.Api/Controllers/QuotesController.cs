using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlackPositivity.Application.Abstractions;
using BlackPositivity.Domain.Models;

namespace BlackPositivity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private IBlackPositivityQuoteApplicationService _quoteService;

        public QuotesController(IBlackPositivityQuoteApplicationService quoteService)
        {
            _quoteService = quoteService;
        }

        // GET: api/Quotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlackPositivityQuote>>> GetBlackPositivityQuotes()
        {
            var quotes = await _quoteService.GetAllQuotes();
            return quotes.ToList();
        }

        // GET: api/Quotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlackPositivityQuote>> GetBlackPositivityQuote(Guid id)
        {
            var blackPositivityQuote = await _quoteService.GetQuote(id);

            if (blackPositivityQuote == null)
            {
                return NotFound();
            }

            return blackPositivityQuote;
        }

        // PUT: api/Quotes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlackPositivityQuote(Guid id, BlackPositivityQuote blackPositivityQuote)
        {
            if (id != blackPositivityQuote.ID)
            {
                return BadRequest();
            }

            var success = await _quoteService.UpdateQuote(id, blackPositivityQuote);

            if (success)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Quotes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BlackPositivityQuote>> PostBlackPositivityQuote(BlackPositivityQuote blackPositivityQuote)
        {
            return await _quoteService.CreateQuote(blackPositivityQuote);
        }

        // DELETE: api/Quotes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BlackPositivityQuote>> DeleteBlackPositivityQuote(Guid id)
        {
            var blackPositivityQuote = await _quoteService.DeleteQuote(id);
            if (blackPositivityQuote == null)
            {
                return NotFound();
            }

            return blackPositivityQuote;
        }
    }
}
