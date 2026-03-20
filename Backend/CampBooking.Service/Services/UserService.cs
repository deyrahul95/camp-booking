using AutoMapper;
using CampBooking.DAL.Interfaces;
using CampBooking.Domain.DTOs;
using CampBooking.Domain.Entities;
using CampBooking.Service.Interfaces;

namespace CampBooking.Service.Services;

/// <summary>
/// Service class for managing user operations.
/// Implements the IUserService interface.
/// </summary>
/// <param name="uow">The unit of work instance used for database operations.</param>
/// <param name="mapper">The mapper instance used for mapping between entities and DTOs.</param>
public class UserService(IUnitOfWork uow, IMapper mapper) : IUserService
{
    /// <summary>
    /// Authenticates a user using their email and password.
    /// </summary>
    /// <param name="user">The user information for login.</param>
    /// <returns>True if the login is successful; otherwise, false.</returns>
    public bool LoginUsingEmailAndPassword(LoginUser user)
    {
        var mapped = mapper.Map<User>(user);
        var result = uow.UserRepository.UserLogin(mapped);
        return result;
    }

    /// <summary>
    /// Retrieves the details of a user by their email address.
    /// </summary>
    /// <param name="email">The email address of the user.</param>
    /// <returns>The details of the user associated with the specified email.</returns>
    public LoginUserDetails GetUserDetails(string email)
    {
        var result = uow.UserRepository.FindUserByEmail(email);

        if (result == null)
        {
            return null;
        }

        var mapped = mapper.Map<LoginUserDetails>(result);
        return mapped;
    }
}