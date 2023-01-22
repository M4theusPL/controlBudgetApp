using AplikacjaInzynierska.Data;
using Microsoft.EntityFrameworkCore;

namespace AplikacjaInzynierska.Services
{
    public class LogsService
    {
        protected readonly ApplicationDbContext _dbcontext;

        public LogsService(ApplicationDbContext _db)
        {
            _dbcontext = _db;
        }

        public bool AddNewEvent(LogsClass log)
        {
            log.time = log.time.AddHours(1);
            _dbcontext.logs.Add(log);
            _dbcontext.SaveChanges();
            return true;
        }

    }
}
