using API.DTO;
using BusinessObject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.IService;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles ="admin, chef")]
        [HttpGet("[action]")]
        public ActionResult<List<User>> GetAll()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("[action]")]
        public ActionResult AddUser([FromBody] NewUserDTO newUserDTO)
        {
            var roleId = 0;
            switch (newUserDTO.RoleName)
            {
                case "parent":
                    roleId = 3;
                    break;
                case "teacher":
                    roleId = 2;
                    break;
                case "chef":
                    roleId = 4;
                    break;
            }
            var user = new User()
            {
                FullName = newUserDTO.FullName,
                Password = newUserDTO.Password,
                UserName = newUserDTO.UserName,
                Phone = newUserDTO.Phone,
                RoleId = roleId
            };
            _userService.AddUser(user);
            return Ok();
        }

        [Authorize(Roles ="admin")]
        [HttpPut("[action]/{userId}")]
        public ActionResult UpdateUser(int userId, [FromBody] NewUserDTO newUserDTO)
        {
            var user = _userService.GetById(userId);
            if (user == null)
            {
                return BadRequest();
            }
            try
            {
                user.FullName = newUserDTO.FullName;
                user.Password = newUserDTO.Password;
                user.UserName = newUserDTO.UserName;
                user.Phone = newUserDTO.Phone;
                _userService.UpdateUser(user);
                return Ok();

            } catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the user. Please try again later.");
            }
        }


        [Authorize(Roles = "admin")]
        [HttpPut("[action]/{userId}")]
        public ActionResult GetDetails(int userId)
        {
            var user = _userService.GetById(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("[action]")]
        public IActionResult GetCurrentUser()
        {
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                var userIdClaim = identity.FindFirst("UserID");
                if (userIdClaim != null)
                {
                    var userId = int.Parse(userIdClaim.Value);
                    var user = _userService.GetById(userId);
                    if (user != null)
                    {
                        return Ok(user);
                    }
                }
            }

            return Unauthorized("User not found");
        }
    }
}
