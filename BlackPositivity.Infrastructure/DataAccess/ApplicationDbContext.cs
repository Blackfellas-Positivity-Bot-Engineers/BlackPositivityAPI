using BlackPositivity.Domain;
using BlackPositivity.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BlackPositivity.Infrastructure.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        
        public DbSet<BlackPositivityQuote> BlackPositivityQuotes { get; set; }
    }
}