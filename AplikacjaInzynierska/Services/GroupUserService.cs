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

        //public GroupUserClass? SearchAddNewUser(string name, string surname, string email, string password, string date_birthday)
        //{
        //    Console.WriteLine("My debug output.");

        //    var newUser = new GroupUserClass();
        //        {
        //            newUser.admin_group = "Admin";
        //            newUser.name = name;
        //            newUser.surname = surname;
        //            newUser.date_birthday = date_birthday;
        //            newUser.email = email;
        //            newUser.password = password;
        //        };

        //        _dbcontext.GroupUserClass.Add(newUser);
        //        _dbcontext.SaveChanges();

        //    return Ok;
        //}

        public GroupUserClass AddnewUser(GroupUserClass gu)
        {
            _dbcontext.Database.ExecuteSqlRaw("DEFUALT", 0, gu.admin_group, gu.name, gu.surname, gu.date_birthday, gu.email, gu.password);
            _dbcontext.SaveChanges();
            return gu;
        }


    }
}