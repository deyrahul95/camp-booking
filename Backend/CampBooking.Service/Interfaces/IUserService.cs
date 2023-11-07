using CampBooking.Domain.DTOs;

namespace CampBooking.Service.Interfaces
{
    public interface IUserService
    {
        bool LoginUsingEmailAndPassword(LoginUser _user);
        LoginUserDetails GetUserDetails(string _email);
    }
}
