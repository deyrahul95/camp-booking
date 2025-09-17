using CampBooking.Domain.DTOs;

namespace CampBooking.Service.Interfaces;

/// <summary>
/// Interface for managing user-related services.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Authenticates a user using their email and password.
    /// </summary>
    /// <param name="user">The user information for login.</param>
    /// <returns>True if the login is successful; otherwise, false.</returns>
    bool LoginUsingEmailAndPassword(LoginUser user);

    /// <summary>
    /// Retrieves the details of a user by their email address.
    /// </summary>
    /// <param name="email">The email address of the user.</param>
    /// <returns>The details of the user associated with the specified email.</returns>
    LoginUserDetails GetUserDetails(string email);
}