using CampBooking.Domain.DTOs;
using CampBooking.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CampBooking.WebApi.Controllers
{
    [ApiController]
    [Route("api/Rating")]
    public class RatingController : Controller
    {
        private readonly IRatingService service;

        public RatingController(IRatingService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        [Route("{campId:guid}")]
        public async Task<IActionResult> GetRating([FromRoute] Guid campId)
        {
            var result = await service.GetRating(campId);

            return Ok(result);
        }

        [HttpGet]
        [Route("comments/{campId:guid}")]
        public async Task<IActionResult> GetComments([FromRoute] Guid campId)
        {
            var result = await service.GetComments(campId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddRating(AddRatingDTO _rating)
        {
            var data = new SearchRatingDTO()
            {
                CampId = _rating.CampId,
                CellPhone = _rating.CellPhone,
                ReferenceNumber = _rating.ReferenceNumber,
            };
            var found = await service.SearchRating(data);
            if(found == null)
            {
                var result = await service.AddNewRating(_rating);
                return Ok(result);
            }
            else
            {
                var result = await service.UpdateRating(found.Id, found);
                return Ok(result);
            }
        }
    }
}
