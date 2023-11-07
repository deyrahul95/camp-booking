using CampBooking.Domain.DTOs;
using CampBooking.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CampBooking.WebApi.Controllers
{
    [ApiController]
    [Route("api/Booking")]
    public class BookingController : Controller
    {
        private readonly IBookService service;

        public BookingController(IBookService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await service.GetAllBookingDetails();
            return Ok(list);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetDetails([FromRoute] Guid id)
        {
            var result = await service.ViewBookingDetails(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBooking(AddBookDTO _book)
        {
            var result = await service.AddNewBooking(_book);
            if (result != "null")
            {
                return Ok(result);
            }
            return Ok("Error on Booking");
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> CancleBooking([FromRoute] Guid id)
        {
            var result = await service.DeleteBooking(id);
            if (result)
            {
                return Ok(result);
            }
            return Ok("Delete Booking Failed!");
        }

        [HttpPost]
        [Route("search-booking")]
        public async Task<IActionResult> SearchBooking(SearchBookingDTO _searchBook)
        {
            var result = await service.SearchBooking(_searchBook.RefNum, _searchBook.Phone, _searchBook.Zipcode);
            if(result == null)
            {
                return Ok("Not Found");
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("is-free")]
        public async Task<IActionResult> IsFreeForBook(CheckForFreeDTO _data)
        {
            var result = await service.FreeForBook(_data);
           
            return Ok(result);
        }

        [HttpPost]
        [Route("search-free-camps")]
        public async Task<IActionResult> FreeCampsForBooking(SearchFreeCampsDTO _data)
        {
            var result = await service.GetAllFreeCampsForBooking(_data);
            return Ok(result);
        }
    }
}
