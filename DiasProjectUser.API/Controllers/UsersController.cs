using DiasProjectUser.Business.Abstract;
using DiasProjectUser.Business.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserFinder.Entities;

namespace DiasProjectUser.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController()
        {
            _userService=new UserManager();
        }
        [Route("GetUsers")]
        [HttpGet]
        public List<User> Get()
        {
            return _userService.GetAllUsers();
        }
        [Route("RegisterEmail")]
        [HttpPost]
        public void Post([FromBody] User user)
        {
            _userService.CreateUserInitial(user);
        }
        [Route("SetPassword")]
        [HttpPut]
        public void Put([FromBody]User user)
        {
            _userService.SetUserPassword(user);
        }
    }
}
