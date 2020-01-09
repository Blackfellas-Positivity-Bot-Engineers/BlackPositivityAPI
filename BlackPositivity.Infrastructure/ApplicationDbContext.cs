using BlackPositivity.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlackPositivity.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        
        public DbSet<BlackPositivityQuote> BlackPositivityQuotes { get; set; }
    }
}