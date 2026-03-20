namespace CampBooking.Domain.DTOs;

/// <summary>
/// Represents a data transfer object (DTO) for user login credentials.
/// </summary>
/// <param name="Email">The email address used for user authentication.</param>
/// <param name="Password">The user's password for login verification.</param>
public record LoginUser(string Email, string Password);
