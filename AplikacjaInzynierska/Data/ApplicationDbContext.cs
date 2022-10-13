using Microsoft.EntityFrameworkCore;

namespace AplikacjaInzynierska.Data
{
    public class ApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }

        public DbSet<StudentClass> student { get; set; }
    }
}
