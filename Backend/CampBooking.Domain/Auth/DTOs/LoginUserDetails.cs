namespace CampBooking.Domain.Auth.DTOs;

/// <summary>
/// Represents a data transfer object (DTO) containing basic user authentication and profile details.
/// </summary>
/// <param name="Name">The user's display name or full name.</param>
/// <param name="Email">The user's email address associated with their account.</param>
/// <param name="IsAdmin">A boolean flag indicating whether the user has administrative privileges.</param>
public record LoginUserDetails(string Name, string Email, bool IsAdmin);
