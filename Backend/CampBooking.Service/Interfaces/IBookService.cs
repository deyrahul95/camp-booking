using CampBooking.Domain.DTOs;

namespace CampBooking.Service.Interfaces
{
    public interface IBookService
    {
        Task<IList<BookDetailsDTO>> GetAllBookingDetails();
        Task<BookDetailsDTO> ViewBookingDetails(Guid Id);
        Task<string> AddNewBooking(AddBookDTO _booking);
        Task<bool> DeleteBooking(Guid _id);
        Task<BookDetailsDTO> SearchBooking(string _refNum, string _phone, string _zipcode);
        Task<bool> FreeForBook(CheckForFreeDTO _data);
        Task<IList<CampDetailsDTO>> GetAllFreeCampsForBooking(SearchFreeCampsDTO _data);
    }
}
