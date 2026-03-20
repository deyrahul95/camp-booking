using CampBooking.Domain.Auth.DTOs;
using CampBooking.Domain.Users.DTOs;
using CampBooking.Domain.Users.Entity;

namespace CampBooking.Shared.Mappers;

/// <summary>
/// Represent user extensions mapper
/// </summary>
public static class UserMapper
{
    /// <summary>
    /// Mapped user object to user details object
    /// </summary>
    /// <param name="user">The user object</param>
    /// <returns>returns user details object</returns>
    public static UserDetails ToUserDetails(this User user) => new(
        Id: user.Id,
        Name: user.Name,
        Email: user.Email,
        Password: user.Password,
        IsAdmin: user.IsAdmin);

    /// <summary>
    /// Mapped user object to user details object
    /// </summary>
    /// <param name="user">The user object</param>
    /// <returns>returns user details object</returns>
    public static LoginUserDetails ToLoginUserDetails(this User user) => new(
        Name: user.Name,
        Email: user.Email,
        IsAdmin: user.IsAdmin);

    /// <summary>
    /// Mapped login user object to user entity
    /// </summary>
    /// <param name="loginUser">Login user details</param>
    /// <returns>Return user entity</returns>
    public static User ToEntity(this LoginUser loginUser) => new()
    {
        Email = loginUser.Email,
        Password = loginUser.Password
    };
}
