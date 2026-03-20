using CampBooking.Domain.Bookings.Entity;

namespace CampBooking.DAL.Interfaces;

/// <summary>
/// Repository interface for managing <c>BookingDetails</c> entities.
/// </summary>
public interface IBookingDetailsRepo
{
    /// <summary>
    /// Retrieves all booking details.
    /// </summary>
    /// <returns>A task that resolves to a list of all <c>BookingDetails</c> records.</returns>
    Task<IList<BookingDetails>> GetAllBookingDetails();

    /// <summary>
    /// Retrieves a single booking detail by its identifier.
    /// </summary>
    /// <param name="Id">The unique identifier of the booking detail.</param>
    /// <returns>A task that resolves to the matching <c>BookingDetails</c> instance.</returns>
    Task<BookingDetails?> GetBookingDetails(Guid Id);

    /// <summary>
    /// Adds a new booking detail to the data store.
    /// </summary>
    /// <param name="book">The booking detail entity to add.</param>
    /// <returns>A task that resolves to a string, typically the identifier of the newly created record.</returns>
    Task<string> AddBookingDetails(BookingDetails book);

    /// <summary>
    /// Deletes an existing booking detail.
    /// </summary>
    /// <param name="Id">The unique identifier of the booking detail to delete.</param>
    /// <returns>A task that resolves to <c>true</c> if the deletion succeeded; otherwise <c>false</c>.</returns>
    Task<bool> DeleteBookingDetails(Guid Id);
}