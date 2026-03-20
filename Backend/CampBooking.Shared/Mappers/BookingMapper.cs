using CampBooking.Domain.Bookings.DTOs;
using CampBooking.Domain.Bookings.Entity;
using CampBooking.Domain.Camps.DTOs;

namespace CampBooking.Shared.Mappers;

/// <summary>
/// Represent booking extensions mapper
/// </summary>
public static class BookingMapper
{
    /// <summary>
    /// Mapped booking details entity to booking details dto object
    /// </summary>
    /// <param name="booking"></param>
    /// <returns></returns>
    public static BookingDetailsDTO ToDto(this BookingDetails booking) => new(
        Id: booking.Id,
        CampId: booking.CampId,
        ReferenceNumber: booking.ReferenceNumber,
        Price: booking.Price,
        Persons: booking.Persons,
        Nights: booking.Nights,
        CheckIn: booking.CheckIn,
        CheckOut: booking.CheckOut,
        Address: booking.Address,
        State: booking.State,
        Country: booking.Country,
        ZipCode: booking.ZipCode,
        CellPhone: booking.CellPhone);

    /// <summary>
    /// Mapped list of booking details entity to list og booking details dto object
    /// </summary>
    /// <param name="bookings"></param>
    /// <returns></returns>
    public static IList<BookingDetailsDTO> ToDtoList(this IList<BookingDetails> bookings)
        => [.. bookings.Select(b => b.ToDto())];

    /// <summary>
    /// Mapped add booking dto to check for free dto object
    /// </summary>
    /// <param name="booking">Add booking dto object</param>
    /// <returns>Return check for free dto object</returns>
    public static CheckForFreeDTO ToFreeDto(this AddBookingDTO booking) => new(
        CampId: booking.CampId,
        CheckIn: booking.CheckIn,
        CheckOut: booking.CheckOut);

    /// <summary>
    /// Mapped booking dto to booking details entity
    /// </summary>
    /// <param name="booking">Booking dto object</param>
    /// <returns>Returns booking details object</returns>
    public static BookingDetails ToEntity(this AddBookingDTO booking) => new()
    {
        Id = Guid.NewGuid(),
        CampId = booking.CampId,
        Address = booking.Address,
        State = booking.State,
        Country = booking.Country,
        ZipCode = booking.ZipCode,
        CellPhone = booking.CellPhone,
        CheckIn = booking.CheckIn,
        CheckOut = booking.CheckOut,
        Nights = booking.Nights,
        Persons = booking.Persons,
        Price = booking.Price
    };
}
