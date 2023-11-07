using CampBooking.Domain.DTOs;
using CampBooking.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CampBooking.WebApi.Controllers
{
    [ApiController]
    [Route("api/Camp")]
    public class CampController : Controller
    {
        private readonly ICampService service;

        public CampController(ICampService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await service.GetAllCamps();
            return Ok(list);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetDetails([FromRoute] Guid id)
        {
            var result = await service.ViewCampDetails(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCamp(AddCampDTO _camp)
        {
            var result = await service.AddNewCamp(_camp);
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> EditCamp([FromRoute] Guid id, CampDetailsDTO _editcamp)
        {
            var result = await service.EditCamp(id, _editcamp);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCamp([FromRoute] Guid id)
        {
            var result = await service.DeleteCampDetails(id);
            if (result == false)
            {
                return Ok(false);
            }
            return Ok(result);
        }
    }
}
