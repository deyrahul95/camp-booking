using CampBooking.DAL.Interfaces;
using CampBooking.Domain.Auth.DTOs;
using CampBooking.Domain.Users.Entity;
using CampBooking.Service.Interfaces;
using CampBooking.Shared.Mappers;

namespace CampBooking.Service.Services;

/// <summary>
/// Service class for managing user operations.
/// Implements the IUserService interface.
/// </summary>
/// <param name="uow">The unit of work instance used for database operations.</param>
public class UserService(IUnitOfWork uow) : IUserService
{
    /// <summary>
    /// Authenticates a user using their email and password.
    /// </summary>
    /// <param name="user">The user information for login.</param>
    /// <returns>True if the login is successful; otherwise, false.</returns>
    public bool LoginUsingEmailAndPassword(LoginUser user)
    {
        var result = uow.UserRepository.UserLogin(user.ToEntity());
        return result;
    }

    /// <summary>
    /// Retrieves the details of a user by their email address.
    /// </summary>
    /// <param name="email">The email address of the user.</param>
    /// <returns>The details of the user associated with the specified email.</returns>
    public LoginUserDetails? GetUserDetails(string email)
    {
        var user = uow.UserRepository.FindUserByEmail(email);

        if (user == null)
        {
            return null;
        }

        return user.ToLoginUserDetails();
    }
}