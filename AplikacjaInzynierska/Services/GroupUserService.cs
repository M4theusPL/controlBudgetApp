using AplikacjaInzynierska.Data;

namespace AplikacjaInzynierska.Services
{
    public class GroupUserService
    {
        protected readonly ApplicationDbContext _dbcontext;

        public GroupUserService(ApplicationDbContext _db)
        {
            _dbcontext = _db;
        }

        public List<GroupUserClass> displayuser()
        {
            return _dbcontext.users.ToList();
        }
    }
}
