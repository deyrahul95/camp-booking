using CampBooking.DAL.DB;
using CampBooking.DAL.Interfaces;
using CampBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace CampBooking.DAL.Repository
{
    public class BookingDetailsRepo : IBookingDetailsRepo
    {
        private readonly CampDBContext _context;

        public BookingDetailsRepo(CampDBContext context)
        {
            _context = context;
        }

        public async Task<IList<BookingDetails>> GetAllBookingDetails()
        {
            return await _context.BookingDetails.ToListAsync();
        }

        public async Task<BookingDetails> GetBookingDetails(Guid Id)
        {
            return await _context.BookingDetails.FindAsync(Id);
        }

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
            await _context.BookingDetails.AddAsync(newBooking);
            return newBooking.ReferenceNumber;
        }

        public async Task<bool> DeleteBookingDetails(Guid Id)
        {
            try
            {
                var book = await _context.BookingDetails.FindAsync(Id);
                 _context.BookingDetails.Remove(book);
                return true;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
