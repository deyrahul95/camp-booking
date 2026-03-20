using CampBooking.DAL.DB;
using CampBooking.DAL.Interfaces;
using CampBooking.Domain.Entities;

namespace CampBooking.DAL.Repository;

/// <summary>
/// Repository class for managing user-related operations in the CampDB context.
/// Implements the IUserRepository interface.
/// </summary>
/// <param name="context">The CampDBContext instance used for database operations.</param>
public class UserRepository(CampDBContext context) : IUserRepository
{
    /// <summary>
    /// Authenticates a user based on the provided user information.
    /// </summary>
    /// <param name="user">The user information for login.</param>
    /// <returns>True if the login is successful; otherwise, false.</returns>
    public bool UserLogin(User user)
    {
        var userAvailable = context.Users
            .Where(u => u.Email == user.Email && u.Password == user.Password)
            .FirstOrDefault();

        if (userAvailable == null)
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// Finds a user by their email address.
    /// </summary>
    /// <param name="email">The email address of the user to find.</param>
    /// <returns>The user associated with the specified email, or null if not found.</returns>
    public User FindUserByEmail(string email)
    {
        var user = context.Users
            .Where(u => u.Email == email)
            .FirstOrDefault();

        if (user == null)
        {
            return null;
        }

        return user;
    }
}