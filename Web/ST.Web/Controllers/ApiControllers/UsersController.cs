using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ST.SharedInterfacesLib;
using ST.SharedUserEntitiesLib;
using ST.Web.Services;

namespace ST.Web.Controllers.ApiControllers
{
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/signup")]
        public IActionResult SignUp([FromBody]User user)
        {
            User result =  _userService.SignUp(user);

            if (result != null)
            {
                return CreatedAtRoute(
                    routeName: "User",
                    routeValues: new { id = result.Id },
                    value: result);
            }
            else
            {
                return BadRequest(new { message = "Username could not be added.  Is this user already registered?" });
            }
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
