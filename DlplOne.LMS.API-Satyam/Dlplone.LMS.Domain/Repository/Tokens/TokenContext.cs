using Microsoft.EntityFrameworkCore;
using Dlplone.LMS.DTO.Infrastructure;

namespace Dlplone.LMS.Domain
{
    public class TokenContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TokenDb");
        }
        public DbSet<Token> Tokens { get; set; }
    }
}
