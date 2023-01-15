using AplikacjaInzynierska.Data;

namespace AplikacjaInzynierska.Services
{
    public class GroupService
    {

        protected readonly ApplicationDbContext _dbcontext;

        public GroupService(ApplicationDbContext _db)
        {
            _dbcontext = _db;
        }

        public GroupClass? GetGroupName(int id_group)
        {
            return _dbcontext.group.FirstOrDefault(x => x.id_group == id_group);
        }

        public async Task<int> AddNewGroup(GroupClass gc)
        {
            _dbcontext.group.Add(gc);
            await _dbcontext.SaveChangesAsync();
            return gc.id_group;
        }

        public bool DeleteGroup(int id_group)
        {
            var delete = _dbcontext.group.Where(u => u.id_group == id_group).First();
            if (delete != null)
            {
                _dbcontext.group.Remove(delete);
                _dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}