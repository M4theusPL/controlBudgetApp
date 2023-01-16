using AplikacjaInzynierska.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;

namespace AplikacjaInzynierska.Services
{
    public class UsersService
    {
        protected readonly ApplicationDbContext _dbcontext;

        public UsersService(ApplicationDbContext _db)
        {
            _dbcontext = _db;
        }

        public List<UsersClass> displayuser()
        {
            return _dbcontext.users.ToList();
        }
        
        public List<UsersClass> displayUsersGroup(int Id)
        {
            return _dbcontext.users.Where(x => x.id_group == Id).ToList();
        }

        public UsersClass? GetByUserEmail(string email)
        {
            return _dbcontext.users.FirstOrDefault(x => x.email == email);
        }

        public UsersClass? GetByUserIdUser(int id_user)
        {
            return _dbcontext.users.FirstOrDefault(x => x.id_user == id_user);
        }

        public async Task<UsersClass> GetByUserAsync(int Id)
        {
            UsersClass employee = await _dbcontext.users.FirstOrDefaultAsync(c => c.id_user.Equals(Id));
            return employee;
        }

        public UsersClass? GetByUserIdGroup(int id_group)
        {
            return _dbcontext.users.FirstOrDefault(x => x.id_group == id_group);
        }

        public bool AddNewUser(UsersClass gc)
        {
            _dbcontext.users.Add(gc);
            _dbcontext.SaveChanges();
            return true;
        }

        public bool EditUser(UsersClass uc, int id_user, string newpassword)
        {
            var checkUser = _dbcontext.users.Where(u => u.id_user == id_user).First();
            if (checkUser != null)
            {
                if(newpassword == null)
                {
                    checkUser.email = uc.email;
                    checkUser.name = uc.name;
                    checkUser.surname = uc.surname;
                    checkUser.date_birthday = uc.date_birthday.ToUniversalTime().AddDays(1);
                    checkUser.password = checkUser.password;
                    _dbcontext.users.Update(checkUser);
                    _dbcontext.SaveChanges();
                    return true;
                }
                else
                {
                    var checkUserWithPassword = _dbcontext.users.Where(u => u.id_user == id_user && u.password == uc.password).First();
                    checkUserWithPassword.email = uc.email;
                    checkUserWithPassword.name = uc.name;
                    checkUserWithPassword.surname = uc.surname;
                    checkUserWithPassword.date_birthday = uc.date_birthday.ToUniversalTime().AddDays(1);
                    checkUserWithPassword.password = newpassword;
                    _dbcontext.users.Update(checkUserWithPassword);
                    _dbcontext.SaveChanges();
                    return true;
                }
            }
            else
            {
                return false;
            }
           
        }

        public bool EditUserGroup(UsersClass uc)
        {
            var update = _dbcontext.users.Where(u => u.id_user == uc.id_user).First();
            if (update != null)
            {
                update.email = uc.email;
                update.name = uc.name;
                update.surname = uc.surname;
                update.password = update.password;
                update.date_birthday = update.date_birthday.ToUniversalTime().AddDays(1);
                update.admin_group = uc.admin_group;
                update.id_group = update.id_group;
                _dbcontext.users.Update(update);
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

        public bool CheckEmail(string email)
        {
            if (_dbcontext.users.Any(u => u.email == email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public UsersClass? GetByIdGroup(int id_group)
        {
            return _dbcontext.users.FirstOrDefault(x => x.id_group == id_group);
        }

        public bool AddUserGroup(UsersClass gc)
        {
            var upp = _dbcontext.users.Where(u => u.email == gc.email).First();
            if (upp != null)
            {
                upp.id_user = gc.id_user;
                upp.email = gc.email;
                upp.id_group = gc.id_group;
                upp.date_birthday = upp.date_birthday.ToUniversalTime();
                upp.admin_group = gc.admin_group;
                _dbcontext.users.Update(upp);
                _dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<int> ilejestwgrupie(int id_group)
        {
            int upp = _dbcontext.users.Where(u => u.id_group == id_group).Count();
            return upp;
        }

        public async Task<int> ilejestwgrupieadminow(int id_group)
        {
            int upp = _dbcontext.users.Where(u => u.id_group == id_group && u.admin_group == "Admin").Count();
            return upp;
        }
    }
}