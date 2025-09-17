namespace CampBooking.Domain.DTOs;

/// <summary>
/// Represents a data transfer object (DTO) for adding a new book or reservation.
/// </summary>
/// <param name="CampId">The unique identifier of the camping location or booking.</param>
/// <param name="Price">The total price of the booking in the local currency.</param>
/// <param name="Persons">The number of people included in the booking.</param>
/// <param name="Nights">The total number of nights for the stay.</param>
/// <param name="CheckIn">The check-in date as a string, representing the start of the booking.</param>
/// <param name="CheckOut">The check-out date as a string, representing the end of the booking.</param>
/// <param name="Address">The physical address of the booking location.</param>
/// <param name="State">The state or region where the booking is located.</param>
/// <param name="Country">The country of the booking location.</param>
/// <param name="ZipCode">The postal code or ZIP code of the booking location.</param>
/// <param name="CellPhone">The contact phone number associated with the booking.</param>
public record AddBookDTO(
    Guid CampId,
    int Price,
    int Persons,
    int Nights,
    string CheckIn,
    string CheckOut,
    string Address,
    string State,
    string Country,
    string ZipCode,
    string CellPhone);
