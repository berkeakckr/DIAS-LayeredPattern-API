using DiasProjectUser.Business.Abstract;
using DiasProjectUser.Business.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            _userService = new UserManager();
        }
        [Route("GetUsers")]
        [HttpGet]
        public List<User> Get()
        {
            return _userService.GetAllUsers();
        }
        [Route("RegisterEmail")]

        [HttpPost]
        "email": "brkfreek@gmail.com"
        public void Post([FromBody] User user)
        {
            _userService.CreateUserInitial(user);
        }
        [Route("CheckVerification")]
        //"email": "brkfreek@gmail.com", swaggera bu şekil girilecek text/json seçip
        //"verificationCode":"53217"
        [HttpPost]
        public void Post2([FromBody] User user)
        {
            _userService.CheckVerificationCode(user);
        }
        [Route("VerificationTimeOut")]
        [HttpPost]
        public void Post3([FromBody]User user)
        {
            _userService.VerificationTimeOut(user);
        }
    }
}
