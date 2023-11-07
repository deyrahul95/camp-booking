using CampBooking.Domain.DTOs;
using CampBooking.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CampBooking.WebApi.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        /// <summary>
        /// Login to camp booking
        /// </summary>
        /// <param name="user">The request user details.</param>
        /// <returns>Returns a response that indicate the login operation.</returns>
        /// <response code="200">Returns "Success".</response>
        /// <response code="400">Bad request if invalid user details.</response>
        [HttpPost]
        public IActionResult Login(LoginUser user)
        {
            var result = _service.LoginUsingEmailAndPassword(user);

            if (result == false)
            {
                return BadRequest();
            }

            return Ok("Success");
        }

        [HttpPost]
        [Route("find-user/{email}")]
        public IActionResult UserDetailsByEmail([FromRoute] string email)
        {
            var result = _service.GetUserDetails(email);
            if(result == null)
            {
                return Json("User Not Found");
            }
            return Json(result);
        }
    }
}
