using CampBooking.Domain.Entities;

namespace CampBooking.DAL.Interfaces;

/// <summary>
/// Interface for managing user-related operations in a repository.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Authenticates a user based on the provided user information.
    /// </summary>
    /// <param name="user">The user information for login.</param>
    /// <returns>True if the login is successful; otherwise, false.</returns>
    bool UserLogin(User user);

    /// <summary>
    /// Finds a user by their email address.
    /// </summary>
    /// <param name="email">The email address of the user to find.</param>
    /// <returns>The user associated with the specified email, or null if not found.</returns>
    User FindUserByEmail(string email);
}