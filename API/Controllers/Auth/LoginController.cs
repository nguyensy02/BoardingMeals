using API.DTO;
using API.Helper;
using BusinessObject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.IService;


namespace API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private IUserService _userService;

        public LoginController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = _userService.GetUserByLogin(userLogin.Username, userLogin.Password);
            var tokenHelper = new TokenHelper(_config);
            if (user != null)
            {
                var token = tokenHelper.Generate(user);
                return Ok(token);
            }
            return NotFound("User not found");
        }
    }
}
