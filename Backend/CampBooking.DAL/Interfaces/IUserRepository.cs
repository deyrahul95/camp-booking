using CampBooking.Domain.Entities;

namespace CampBooking.DAL.Interfaces
{
    public interface IUserRepository
    {
        bool UserLogin(User _user);
        User FindUserByEmail(string _email);
    }
}
