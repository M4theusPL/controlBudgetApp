using AplikacjaInzynierska.Data;
using Microsoft.EntityFrameworkCore;

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
        
        public List<UsersClass> displayUsersGroup(int id)
        {
            var listUsersGroup = _dbcontext.users.Where(x => x.id_group == id);
            listUsersGroup = listUsersGroup.OrderBy(x => x.admin_group);
            return listUsersGroup.ToList();
        }

        public UsersClass? GetByUserEmail(string email)
        {
            return _dbcontext.users.FirstOrDefault(x => x.email == email);
        }

        public UsersClass? GetByUserIdUser(int id_user)
        {
            return _dbcontext.users.FirstOrDefault(x => x.id_user == id_user);
        }

        public async Task<UsersClass> GetByUserAsync(int id)
        {
            UsersClass user = await _dbcontext.users.FirstOrDefaultAsync(c => c.id_user.Equals(id));
            return user;
        }

        public UsersClass? GetByUserIdGroup(int id_group)
        {
            return _dbcontext.users.FirstOrDefault(x => x.id_group == id_group);
        }

        public bool AddNewUser(UsersClass uc)
        {
            _dbcontext.users.Add(uc);
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
                    checkUser.date_birthday = uc.date_birthday.ToUniversalTime();
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
                    checkUserWithPassword.date_birthday = uc.date_birthday.ToUniversalTime();
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
                update.date_birthday = update.date_birthday.ToUniversalTime();
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
            var remove = _dbcontext.users.Where(u => u.id_user == id_user).First();
            if (remove != null)
            {
                remove.email = remove.email;
                remove.password = remove.password;
                remove.date_birthday = remove.date_birthday.ToUniversalTime();
                remove.admin_group = "Admin";
                remove.id_group = 0;
                _dbcontext.users.Update(remove);
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

        public bool AddUserGroup(UsersClass uc)
        {
            var update = _dbcontext.users.Where(u => u.email == uc.email).First();
            if (update != null)
            {
                update.id_user = uc.id_user;
                update.email = uc.email;
                update.id_group = uc.id_group;
                update.date_birthday = update.date_birthday.ToUniversalTime();
                update.admin_group = uc.admin_group;
                _dbcontext.users.Update(update);
                _dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<int> InGroupUsers(int id_group)
        {
            int users = _dbcontext.users.Where(u => u.id_group == id_group).Count();
            return users;
        }

        public async Task<int> InGroupAdmin(int id_group)
        {
            int admins = _dbcontext.users.Where(u => u.id_group == id_group && u.admin_group == "Admin").Count();
            return admins;
        }
    }
}