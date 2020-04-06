using BookManagement.BAL.Implementation;
using BookManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]UserLoginModel userLoginModel)
        {
            bool result = _userManager.Login(userLoginModel);
            if (result)
            {
                return StatusCode((int)HttpStatusCode.OK, result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.NotFound, result);
            }
        }
    }
}