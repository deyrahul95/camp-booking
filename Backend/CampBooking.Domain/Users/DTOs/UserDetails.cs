namespace CampBooking.Domain.Users.DTOs;

/// <summary>
/// Represents a data transfer object (DTO) containing user account details.
/// </summary>
/// <param name="Id">The unique identifier of the user.</param>
/// <param name="Name">The user's display name.</param>
/// <param name="Email">The user's email address.</param>
/// <param name="Password">The user's account password.</param>
/// <param name="IsAdmin">A flag indicating whether the user has administrative privileges.</param>
public record UserDetails(
    int Id,
    string Name,
    string Email,
    string Password,
    bool IsAdmin);
