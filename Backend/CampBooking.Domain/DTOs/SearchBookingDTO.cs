namespace CampBooking.Domain.DTOs;

/// <summary>
/// Represents a data transfer object (DTO) for searching booking information.
/// </summary>
/// <param name="RefNum">The reference number of the booking to search for.</param>
/// <param name="Phone">The contact phone number associated with the booking.</param>
/// <param name="ZipCode">The postal code or ZIP code of the booking location.</param>
public record SearchBookingDTO(string RefNum, string Phone, string ZipCode);
