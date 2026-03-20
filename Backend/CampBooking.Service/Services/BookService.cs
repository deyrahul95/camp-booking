using AutoMapper;
using CampBooking.DAL.Interfaces;
using CampBooking.Domain.Bookings.DTOs;
using CampBooking.Domain.Bookings.Entity;
using CampBooking.Domain.Camps.DTOs;
using CampBooking.Service.Interfaces;
using CampBooking.Shared.HelperFunctions;

namespace CampBooking.Service.Services;

/// <summary>
/// Service class for managing booking operations.
/// Implements the IBookService interface.
/// </summary>
/// <param name="uow">The unit of work instance used for database operations.</param>
/// <param name="mapper">The mapper instance used for mapping between entities and DTOs.</param>
public class BookService(IUnitOfWork uow, IMapper mapper) : IBookService
{
    /// <summary>
    /// Retrieves all booking details.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation, containing a list of booking details DTOs.</returns>
    public async Task<IList<BookingDetailsDTO>> GetAllBookingDetails()
    {
        var list = await uow.BookingDetailsRepository.GetAllBookingDetails();
        var mapped = mapper.Map<IList<BookingDetailsDTO>>(list)
            ?? throw new Exception($"Entity could not be mapped.");

        return mapped;
    }

    /// <summary>
    /// Retrieves specific booking details by its unique identifier.
    /// </summary>
    /// <param name="Id">The unique identifier of the booking.</param>
    /// <returns>A task that represents the asynchronous operation, containing the requested booking details DTO.</returns>
    public async Task<BookingDetailsDTO> ViewBookingDetails(Guid Id)
    {
        var result = await uow.BookingDetailsRepository.GetBookingDetails(Id);
        var mapped = mapper.Map<BookingDetailsDTO>(result)
            ?? throw new Exception($"Entity could not be mapped.");

        return mapped;
    }

    /// <summary>
    /// Adds a new booking.
    /// </summary>
    /// <param name="booking">The booking information to be added.</param>
    /// <returns>A task that represents the asynchronous operation, containing a string message indicating the result.</returns>
    public async Task<string> AddNewBooking(AddBookingDTO booking)
    {
        var isFreeForBook = await FreeForBook(mapper.Map<CheckForFreeDTO>(booking));

        if (isFreeForBook == false)
        {
            return "Camp is Not Free For Book";
        }

        var mapped = mapper.Map<BookingDetails>(booking)
            ?? throw new Exception($"Entity could not be mapped.");

        mapped.Id = Guid.NewGuid();
        mapped.ReferenceNumber = GetReferenceNumber.RandomNumber(
            mapped.Id,
            mapped.CellPhone,
            mapped.ZipCode);

        try
        {
            string refNum = await uow.BookingDetailsRepository.AddBookingDetails(mapped);
            bool res = await uow.SaveAsync();

            if (refNum != null && res)
            {
                return refNum;
            }

            return "null";
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    /// <summary>
    /// Deletes a booking by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the booking to be deleted.</param>
    /// <returns>A task that represents the asynchronous operation, containing a boolean indicating success or failure.</returns>
    public async Task<bool> DeleteBooking(Guid id)
    {
        var result = await uow.BookingDetailsRepository.DeleteBookingDetails(id);

        if (result == false)
        {
            return false;
        }
        return await uow.SaveAsync();
    }

    /// <summary>
    /// Searches for a booking using reference number, phone number, and zip code.
    /// </summary>
    /// <param name="refNum">The reference number of the booking.</param>
    /// <param name="phone">The phone number associated with the booking.</param>
    /// <param name="zipCode">The zip code associated with the booking.</param>
    /// <returns>A task that represents the asynchronous operation, containing the found booking details DTO.</returns>
    public async Task<BookingDetailsDTO> SearchBooking(string refNum, string phone, string zipCode)
    {
        var results = await uow.BookingDetailsRepository.GetAllBookingDetails();

        foreach (var item in results)
        {
            if (item.ReferenceNumber == refNum && item.CellPhone == phone && item.ZipCode == zipCode)
            {
                return mapper.Map<BookingDetailsDTO>(item);
            }
        }

        return null;
    }

    /// <summary>
    /// Checks if a camp is free for booking based on the provided data.
    /// </summary>
    /// <param name="data">The data containing information to check availability.</param>
    /// <returns>A task that represents the asynchronous operation, containing a boolean indicating if the camp is free for booking.</returns>
    public async Task<bool> FreeForBook(CheckForFreeDTO data)
    {
        if (DateTime.Parse(data.CheckIn) > DateTime.Parse(data.CheckOut))
        {
            return false;
        }

        var allDetails = await uow.BookingDetailsRepository.GetAllBookingDetails();
        var result = true;

        foreach (var item in allDetails)
        {
            if (item.CampId == data.CampId)
            {
                if ((DateTime.Parse(data.CheckIn) >= DateTime.Parse(item.CheckIn)) &&
                    (DateTime.Parse(data.CheckIn) < DateTime.Parse(item.CheckOut)))
                {
                    result = false; break;
                }

                if ((DateTime.Parse(data.CheckOut) > DateTime.Parse(item.CheckIn)) &&
                    (DateTime.Parse(data.CheckOut) <= DateTime.Parse(item.CheckOut)))
                {
                    result = false; break;
                }

                if ((DateTime.Parse(item.CheckOut) > DateTime.Parse(data.CheckIn)) &&
                    (DateTime.Parse(item.CheckOut) < DateTime.Parse(data.CheckOut)))
                {
                    result = false; break;
                }

                if ((DateTime.Parse(item.CheckIn) > DateTime.Parse(data.CheckIn)) &&
                    (DateTime.Parse(item.CheckIn) < DateTime.Parse(data.CheckOut)))
                {
                    result = false; break;
                }
            }
        }

        return result;
    }

    /// <summary>
    /// Retrieves all free camps available for booking based on the search criteria.
    /// </summary>
    /// <param name="data">The search criteria for finding free camps.</param>
    /// <returns>A task that represents the asynchronous operation, containing a list of camp details DTOs.</returns>
    public async Task<IList<CampDetailsDTO>> GetAllFreeCampsForBooking(SearchFreeCampsDTO data)
    {
        var campList = await uow.CampRepository.GetCamps();
        var result = new List<CampDetailsDTO>();

        foreach (var item in campList)
        {
            var checkForFreeDto = new CheckForFreeDTO(
                CampId: item.Id,
                CheckOut: data.CheckOut,
                CheckIn: data.CheckIn);

            var res = await FreeForBook(checkForFreeDto);

            if (res == true)
            {
                var mapped = mapper.Map<CampDetailsDTO>(item)
                    ?? throw new Exception($"Entity could not be mapped.");
                result.Add(mapped);
            }
        }

        return result;
    }
}