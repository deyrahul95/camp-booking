using CampBooking.Domain.DTOs;

namespace CampBooking.Service.Interfaces;

/// <summary>
/// Interface for managing booking services related to camp bookings.
/// </summary>
public interface IBookService
{
    /// <summary>
    /// Retrieves all booking details.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation, containing a list of booking details DTOs.</returns>
    Task<IList<BookDetailsDTO>> GetAllBookingDetails();

    /// <summary>
    /// Retrieves specific booking details by its unique identifier.
    /// </summary>
    /// <param name="Id">The unique identifier of the booking.</param>
    /// <returns>A task that represents the asynchronous operation, containing the requested booking details DTO.</returns>
    Task<BookDetailsDTO> ViewBookingDetails(Guid Id);

    /// <summary>
    /// Adds a new booking.
    /// </summary>
    /// <param name="booking">The booking information to be added.</param>
    /// <returns>A task that represents the asynchronous operation, containing a string message indicating the result.</returns>
    Task<string> AddNewBooking(AddBookDTO booking);

    /// <summary>
    /// Deletes a booking by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the booking to be deleted.</param>
    /// <returns>A task that represents the asynchronous operation, containing a boolean indicating success or failure.</returns>
    Task<bool> DeleteBooking(Guid id);

    /// <summary>
    /// Searches for a booking using reference number, phone number, and zip code.
    /// </summary>
    /// <param name="refNum">The reference number of the booking.</param>
    /// <param name="phone">The phone number associated with the booking.</param>
    /// <param name="zipCode">The zip code associated with the booking.</param>
    /// <returns>A task that represents the asynchronous operation, containing the found booking details DTO.</returns>
    Task<BookDetailsDTO> SearchBooking(string refNum, string phone, string zipCode);

    /// <summary>
    /// Checks if a camp is free for booking based on the provided data.
    /// </summary>
    /// <param name="data">The data containing information to check availability.</param>
    /// <returns>A task that represents the asynchronous operation, containing a boolean indicating if the camp is free for booking.</returns>
    Task<bool> FreeForBook(CheckForFreeDTO data);

    /// <summary>
    /// Retrieves all free camps available for booking based on the search criteria.
    /// </summary>
    /// <param name="data">The search criteria for finding free camps.</param>
    /// <returns>A task that represents the asynchronous operation, containing a list of camp details DTOs.</returns>
    Task<IList<CampDetailsDTO>> GetAllFreeCampsForBooking(SearchFreeCampsDTO data);
}