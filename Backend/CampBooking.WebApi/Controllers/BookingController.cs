using CampBooking.Domain.Bookings.DTOs;
using CampBooking.Domain.Camps.DTOs;
using CampBooking.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CampBooking.WebApi.Controllers;

/// <summary>
/// Controller for managing booking operations.
/// </summary>
/// <remarks>
/// This API controller handles requests related to booking services.
/// </remarks>
[ApiController]
[Route("api/Booking")]
public class BookingController(IBookService service) : ControllerBase
{
    /// <summary>
    /// Retrieves all booking details asynchronously.
    /// </summary>
    /// <returns>An IActionResult containing the list of booking details.</returns>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var list = await service.GetAllBookingDetails();
        return Ok(list);
    }

    /// <summary>
    /// Retrieves the details of a specific booking by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the booking.</param>
    /// <returns>An IActionResult containing the details of the specified booking.</returns>
    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetDetails([FromRoute] Guid id)
    {
        var result = await service.ViewBookingDetails(id);
        return Ok(result);
    }

    /// <summary>
    /// Adds a new booking based on the provided booking data transfer object.
    /// </summary>
    /// <param name="book">The data transfer object containing the details of the new booking.</param>
    /// <returns>An IActionResult indicating the result of the add operation.</returns>
    [HttpPost]
    public async Task<IActionResult> AddNewBooking(AddBookingDTO book)
    {
        var result = await service.AddNewBooking(book);

        if (result != "null")
        {
            return Ok(result);
        }

        return Ok("Error on Booking");
    }

    /// <summary>
    /// Cancels a booking identified by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the booking to be canceled.</param>
    /// <returns>An IActionResult indicating the result of the cancel operation.</returns>
    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> CancelBooking([FromRoute] Guid id)
    {
        var result = await service.DeleteBooking(id);

        if (result)
        {
            return Ok(result);
        }

        return Ok("Delete Booking Failed!");
    }

    /// <summary>
    /// Searches for bookings based on the provided search criteria.
    /// </summary>
    /// <param name="searchBook">The data transfer object containing the search criteria for bookings.</param>
    /// <returns>An IActionResult containing the search results.</returns>
    [HttpPost]
    [Route("search-booking")]
    public async Task<IActionResult> SearchBooking(SearchBookingDTO searchBook)
    {
        var result = await service.SearchBooking(
            searchBook.RefNum,
            searchBook.Phone,
            searchBook.ZipCode);

        if (result == null)
        {
            return Ok("Not Found");
        }

        return Ok(result);
    }

    /// <summary>
    /// Checks if a booking slot is available based on the provided criteria.
    /// </summary>
    /// <param name="data">The data transfer object containing the details to check availability.</param>
    /// <returns>An IActionResult indicating whether the booking slot is free.</returns>
    [HttpPost]
    [Route("is-free")]
    public async Task<IActionResult> IsFreeForBook(CheckForFreeDTO data)
    {
        var result = await service.FreeForBook(data);

        return Ok(result);
    }

    /// <summary>
    /// Searches for available camping slots based on the provided criteria.
    /// </summary>
    /// <param name="data">The data transfer object containing the search criteria for free camps.</param>
    /// <returns>An IActionResult containing the search results for available camping slots.</returns>
    [HttpPost]
    [Route("search-free-camps")]
    public async Task<IActionResult> FreeCampsForBooking(SearchFreeCampsDTO data)
    {
        var result = await service.GetAllFreeCampsForBooking(data);
        return Ok(result);
    }
}