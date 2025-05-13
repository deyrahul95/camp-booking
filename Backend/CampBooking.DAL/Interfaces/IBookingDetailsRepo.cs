using CampBooking.Domain.Entities;

namespace CampBooking.DAL.Interfaces
{
    public interface IBookingDetailsRepo
    {
        Task<IList<BookingDetails>> GetAllBookingDetails();
        Task<BookingDetails> GetBookingDetails(Guid Id);
        Task<string> AddBookingDetails(BookingDetails _book);
        Task<bool> DeleteBookingDetails(Guid Id);
    }
}
