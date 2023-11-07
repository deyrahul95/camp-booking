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

        [HttpPost]
        public IActionResult Login(LoginUser _user)
        {
            var result = _service.LoginUsingEmailAndPassword(_user);
            if (result == false)
            {
                return Ok("Failure");
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
