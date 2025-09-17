using CampBooking.Domain.DTOs;
using CampBooking.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CampBooking.WebApi.Controllers;

/// <summary>
/// Controller for managing camp operations.
/// </summary>
/// <remarks>
/// This API controller handles requests related to camp services.
/// </remarks>
[ApiController]
[Route("api/Camp")]
public class CampController(ICampService service) : ControllerBase
{
    /// <summary>
    /// Retrieves all camp details asynchronously.
    /// </summary>
    /// <returns>An IActionResult containing the list of camp details.</returns>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var list = await service.GetAllCamps();
        return Ok(list);
    }

    /// <summary>
    /// Retrieves the details of a specific camp by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the camp.</param>
    /// <returns>An IActionResult containing the details of the specified camp.</returns>
    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetDetails([FromRoute] Guid id)
    {
        var result = await service.ViewCampDetails(id);
        return Ok(result);
    }

    /// <summary>
    /// Adds a new camp based on the provided camp data transfer object.
    /// </summary>
    /// <param name="input">The data transfer object containing the details of the new camp.</param>
    /// <returns>An IActionResult indicating the result of the add operation.</returns>
    [HttpPost]
    public async Task<IActionResult> AddNewCamp(AddCampDTO input)
    {
        var result = await service.AddNewCamp(input);
        if (result != null)
        {
            return Ok(result);
        }
        return BadRequest();
    }

    /// <summary>
    /// Edits an existing camp identified by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the camp to be edited.</param>
    /// <param name="input">The data transfer object containing the updated details of the camp.</param>
    /// <returns>An IActionResult indicating the result of the edit operation.</returns>
    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> EditCamp([FromRoute] Guid id, CampDetailsDTO input)
    {
        var result = await service.EditCamp(id, input);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    /// <summary>
    /// Deletes a camp identified by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the camp to be deleted.</param>
    /// <returns>An IActionResult indicating the result of the delete operation.</returns>
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
