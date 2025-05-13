using CampBooking.DAL.DB;
using CampBooking.DAL.Interfaces;
using CampBooking.Domain.Entities;

namespace CampBooking.DAL.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly CampDBContext _context;

        public UserRepository(CampDBContext context)
        {
            _context = context;
        }

        public bool UserLogin(User _user)
        {
            var userAvailable = _context.Users.Where(u => u.Email == _user.Email && u.Password == _user.Password).FirstOrDefault();
            if(userAvailable == null)
            {
                return false;
            }
            return true;
        }

        public User FindUserByEmail(string _email)
        {
            var user = _context.Users.Where(u => u.Email == _email).FirstOrDefault();
            if(user == null)
            {
                return null;
            }
            return user;
        }
    }
}
