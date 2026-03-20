using CampBooking.DAL.DB;
using CampBooking.DAL.Interfaces;
using CampBooking.Domain.Bookings.Entity;
using Microsoft.EntityFrameworkCore;

namespace CampBooking.DAL.Repository;

/// <summary>
/// Repository class for managing booking details in the CampDB context.
/// Implements the IBookingDetailsRepo interface.
/// </summary>
/// <param name="context">The CampDBContext instance used for database operations.</param>
public class BookingDetailsRepo(CampDBContext context) : IBookingDetailsRepo
{
    /// <summary>
    /// Retrieves all booking details.
    /// </summary>
    /// <returns>A task that resolves to a list of all <c>BookingDetails</c> records.</returns>
    public async Task<IList<BookingDetails>> GetAllBookingDetails()
    {
        return await context.BookingDetails.ToListAsync();
    }

    /// <summary>
    /// Retrieves a single booking detail by its identifier.
    /// </summary>
    /// <param name="Id">The unique identifier of the booking detail.</param>
    /// <returns>A task that resolves to the matching <c>BookingDetails</c> instance.</returns>
    public async Task<BookingDetails?> GetBookingDetails(Guid Id)
    {
        return await context.BookingDetails.FindAsync(Id);
    }

    /// <summary>
    /// Adds a new booking detail to the data store.
    /// </summary>
    /// <param name="_book">The booking detail entity to add.</param>
    /// <returns>A task that resolves to a string, typically the identifier of the newly created record.</returns>
    public async Task<string> AddBookingDetails(BookingDetails _book)
    {
        var newBooking = new BookingDetails()
        {
            Id = _book.Id,
            CampId = _book.CampId,
            ReferenceNumber = _book.ReferenceNumber,
            Price = _book.Price,
            Persons = _book.Persons,
            Nights = _book.Nights,
            CheckIn = _book.CheckIn,
            CheckOut = _book.CheckOut,
            Address = _book.Address,
            State = _book.State,
            Country = _book.Country,
            ZipCode = _book.ZipCode,
            CellPhone = _book.CellPhone
        };

        await context.BookingDetails.AddAsync(newBooking);
        return newBooking.ReferenceNumber;
    }

    /// <summary>
    /// Deletes an existing booking detail.
    /// </summary>
    /// <param name="Id">The unique identifier of the booking detail to delete.</param>
    /// <returns>A task that resolves to <c>true</c> if the deletion succeeded; otherwise <c>false</c>.</returns>
    public async Task<bool> DeleteBookingDetails(Guid Id)
    {
        try
        {
            var book = await context.BookingDetails.FindAsync(Id);

            if (book is null)
            {
                return false;
            }

            context.BookingDetails.Remove(book);
            return true;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
