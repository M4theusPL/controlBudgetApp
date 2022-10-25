using AplikacjaInzynierska.Data;
using Microsoft.EntityFrameworkCore;
using System;

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

        public GroupUserClass? GetByUserEmail(string email)
        {
            return _dbcontext.users.FirstOrDefault(x => x.email == email);
        }

        public GroupUserClass? GetByUserIdGroup(int id_group)
        {
            return _dbcontext.users.FirstOrDefault(x => x.id_group == id_group);
        }

        public bool AddNewUser(GroupUserClass gc)
        {
            _dbcontext.users.Add(gc);
            _dbcontext.SaveChanges();
            return true;
        }
    }
}