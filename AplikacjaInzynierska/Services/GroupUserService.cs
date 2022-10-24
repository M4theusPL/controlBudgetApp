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
        public GroupUserClass? GetByUserName(string email)
        {
            return _dbcontext.users.FirstOrDefault(x => x.email == email);
        }

        //public TaskddNewUser(GroupUserClass newUser)
        //{
        //    _dbcontext.users.Add(newUser);
        //    _dbcontext.SaveChanges();
        //    return true;
        //}
        public bool AddNewUser(GroupUserClass gc)
        {
            _dbcontext.users.Add(gc);
            _dbcontext.SaveChanges();
            return true;
        }


    }
}