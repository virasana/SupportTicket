using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ST.SharedHelpersLib.Exceptions;
using ST.SharedInterfacesLib;
using ST.SharedUserEntitiesLib;
using ST.Web.Services;

namespace ST.Web.Controllers.ApiControllers
{
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService<ISTUsersRepo> _userService;

        public UsersController(IUserService<ISTUsersRepo> userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            try
            {
                var user = _userService.Authenticate(userParam.Username, userParam.Password);
                if (user != null) return Ok(user);
                return Unauthorized();
            }
            catch (SupportTicketDatabaseException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/signup")]
        public IActionResult SignUp([FromBody]User user)
        {
            User result;

            try
            {
                result = _userService.SignUp(user);
            }
            catch (SupportTicketApplicationException ex)
            {
                return BadRequest(ex.Message);
            }

            if (result != null)
            {
                return CreatedAtRoute(
                    routeName: "User",
                    routeValues: new { id = result.Id },
                    value: result);
            }

            return BadRequest(new { message = "Unknown error during signup." });
        }

        [HttpGet]
        [Route("api/users")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet]
        [Route("api/user/{id}", Name = "User")]
        public IActionResult Get(int id)
        {
            var user = _userService.Get(id);
            return Ok(user);
        }
    }
}
