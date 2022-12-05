using AplikacjaInzynierska.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;

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
        
        public List<GroupUserClass> displayUsersGroup(int Id)
        {
            return _dbcontext.users.Where(x => x.id_group == Id).ToList();
        }

        public GroupUserClass? GetByUserEmail(string email)
        {
            return _dbcontext.users.FirstOrDefault(x => x.email == email);
        }

        public GroupUserClass? GetByUserIdUser(int id_user)
        {
            return _dbcontext.users.FirstOrDefault(x => x.id_user == id_user);
        }
        public async Task<GroupUserClass> GetByUserAsync(int Id)
        {
            GroupUserClass employee = await _dbcontext.users.FirstOrDefaultAsync(c => c.id_user.Equals(Id));
            return employee;
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

        public bool EditUser(GroupUserClass gc, string newpassword)
        {
            var up = _dbcontext.users.Where(u => u.email == gc.email).First();
            if (up != null)
            {
                if(newpassword == null)
                {
                    up.email = gc.email;
                    up.name = gc.name;
                    up.surname = gc.surname;
                    up.date_birthday = gc.date_birthday.ToUniversalTime().AddDays(1);
                    up.password = up.password;
                    _dbcontext.users.Update(up);
                    _dbcontext.SaveChanges();
                    return true;
                }
                else
                {
                    var upp = _dbcontext.users.Where(u => u.email == gc.email && u.password == gc.password).First();
                    upp.email = gc.email;
                    upp.name = gc.name;
                    upp.surname = gc.surname;
                    upp.date_birthday = gc.date_birthday.ToUniversalTime().AddDays(1);
                    upp.password = newpassword;
                    _dbcontext.users.Update(upp);
                    _dbcontext.SaveChanges();
                    return true;
                }
                
            }
            else
            {
                return false;
            }
           
        }

        public bool EditUserGroup(GroupUserClass gc)
        {
            var up = _dbcontext.users.Where(u => u.email == gc.email).First();
            if (up != null)
            {
                up.email = gc.email;
                up.name = gc.name;
                up.surname = gc.surname;
                up.password = up.password;
                up.date_birthday = up.date_birthday.ToUniversalTime().AddDays(1);
                up.admin_group = gc.admin_group;
                up.id_group = up.id_group;
                _dbcontext.users.Update(up);
                _dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool RemoveUserGroup(int id_user)
        {
            var up = _dbcontext.users.Where(u => u.id_user == id_user).First();
            if (up != null)
            {
                up.email = up.email;
                up.password = up.password;
                up.date_birthday = up.date_birthday.ToUniversalTime().AddDays(1);
                up.admin_group = "Admin";
                up.id_group = 0;
                _dbcontext.users.Update(up);
                _dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public GroupUserClass? GetByIdGroup(int id_group)
        {
            return _dbcontext.users.FirstOrDefault(x => x.id_group == id_group);
        }

        public bool AddUserGroup(GroupUserClass gc)
        {
            var upp = _dbcontext.users.Where(u => u.email == gc.email).First();
            if (upp != null)
            {
                upp.id_user = gc.id_user;
                upp.email = gc.email;
                upp.id_group = gc.id_group;
                upp.date_birthday = upp.date_birthday.ToUniversalTime();
                _dbcontext.users.Update(upp);
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