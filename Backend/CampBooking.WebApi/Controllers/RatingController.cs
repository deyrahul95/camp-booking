using CampBooking.Domain.DTOs;
using CampBooking.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CampBooking.WebApi.Controllers;

/// <summary>
/// Controller for managing rating operations.
/// </summary>
/// <remarks>
/// This API controller handles requests related to rating services.
/// </remarks>
[ApiController]
[Route("api/Rating")]
public class RatingController(IRatingService service) : ControllerBase
{
    /// <summary>
    /// Retrieves the rating for a specific camp identified by its unique identifier.
    /// </summary>
    /// <param name="campId">The unique identifier of the camp for which to retrieve the rating.</param>
    /// <returns>An IActionResult containing the rating of the specified camp.</returns>
    [HttpGet]
    [Route("{campId:guid}")]
    public async Task<IActionResult> GetRating([FromRoute] Guid campId)
    {
        var result = await service.GetRating(campId);

        return Ok(result);
    }

    /// <summary>
    /// Retrieves comments for a specific camp identified by its unique identifier.
    /// </summary>
    /// <param name="campId">The unique identifier of the camp for which to retrieve comments.</param>
    /// <returns>An IActionResult containing the comments for the specified camp.</returns>
    [HttpGet]
    [Route("comments/{campId:guid}")]
    public async Task<IActionResult> GetComments([FromRoute] Guid campId)
    {
        var result = await service.GetComments(campId);
        return Ok(result);
    }

    /// <summary>
    /// Adds a new rating based on the provided rating data transfer object.
    /// </summary>
    /// <param name="input">The data transfer object containing the details of the new rating.</param>
    /// <returns>An IActionResult indicating the result of the add operation.</returns>
    [HttpPost]
    public async Task<IActionResult> AddRating(AddRatingDTO input)
    {
        var data = new SearchRatingDTO(
            CampId: input.CampId,
            CellPhone: input.CellPhone,
            ReferenceNumber: input.ReferenceNumber);

        var found = await service.SearchRating(data);

        if (found == null)
        {
            var addedResult = await service.AddNewRating(input);
            return Ok(addedResult);
        }

        var updatedResult = await service.UpdateRating(found.Id, found);
        return Ok(updatedResult);
    }
}