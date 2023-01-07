using Microsoft.EntityFrameworkCore;

namespace AplikacjaInzynierska.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<GroupUserClass> users { get; set; }

        public DbSet<TransactionsClass> transactions { get; set; }

        public DbSet<LogsClass> logs { get; set; }
    }
}
