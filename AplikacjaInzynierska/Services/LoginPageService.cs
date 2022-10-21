using AplikacjaInzynierska.Data;
using System.Runtime.CompilerServices;

namespace AplikacjaInzynierska.Services
{
    public class LoginPageService
    {
        protected readonly ApplicationDbContext _dbcontext;

        public LoginPageService(ApplicationDbContext _db)
        {
            _dbcontext = _db;
        }

        //public List<LoginPageClass> searchEmail(string email)
        //{
        //    return _dbcontext.login.Where(x => x.email == email).ToList();
        //}

        //public List<LoginPageClass> searchPassword(string password)
        //{
        //    return _dbcontext.login.Where(x => x.password == password).ToList();
        //}
    }
}
