using CodeChallenge.Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.Infrastructure.Persistence
{
    public class CodeChallengeDbContext : DbContext
    {
        public CodeChallengeDbContext(DbContextOptions<CodeChallengeDbContext> options)
              : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
