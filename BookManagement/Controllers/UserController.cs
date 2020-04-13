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
        public IActionResult Login([FromBody]UserModel userLoginModel)
        {
            var result = _userManager.Login(userLoginModel);
            if (result != null)
            {  
                var token = _userManager.GenerateJSONWebToken(result);
                return StatusCode((int)HttpStatusCode.OK, new { authtoken = token, user = result });
            }
            else
            {
                return StatusCode((int)HttpStatusCode.NotFound, result);
            }
        }
    }
}