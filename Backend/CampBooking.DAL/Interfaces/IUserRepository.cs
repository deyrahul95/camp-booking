using CampBooking.DAL.DbModel;

namespace CampBooking.DAL.Interfaces
{
    public interface IUserRepository
    {
        bool UserLogin(User _user);
        User FindUserByEmail(string _email);
    }
}
