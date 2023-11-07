using CampBooking.Domain.DTOs;
using CampBooking.Service.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CampBooking.WebApi.Controllers;

/// <summary>
/// Represents user controller for managing user details.
/// </summary>
[ApiController]
[Route("api/User")]
[Produces("application/json")]
public class UserController : Controller
{
    /// <summary>
    /// Represents user service interface.
    /// </summary>
    private readonly IUserService _service;

    /// <summary>
    /// Create an instance of UserController class.
    /// </summary>
    /// <param name="service">The user service interface.</param>
    public UserController(IUserService service)
    {
        _service = service;
    }

    /// <summary>
    /// Login to camp booking.
    /// </summary>
    /// <param name="user">The request user details.</param>
    /// <returns>Returns a response indicating the login operation result.</returns>
    /// <response code="200">Returns "Success".</response>
    /// <response code="400">Bad request if invalid user details.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequest))]
    public IActionResult Login(LoginUser user)
    {
        var result = _service.LoginUsingEmailAndPassword(user);

        if (result == false)
        {
            return BadRequest();
        }

        return Ok("Success");
    }

    /// <summary>
    /// Check request user is present or not.
    /// </summary>
    /// <param name="email">The request user unique identifier email id.</param>
    /// <returns>Returns a response indicating the user details is found or not.</returns>
    /// <response code="200">Returns user details.</response>
    /// <response code="404">Not Found if user not present.</response>
    [HttpPost]
    [Route("find-user/{email}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginUserDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFound))]
    public IActionResult UserDetailsByEmail([FromRoute] string email)
    {
        var result = _service.GetUserDetails(email);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}
