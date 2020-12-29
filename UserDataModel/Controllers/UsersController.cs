using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using UserDataModel.Models;
using UserDataModel.UserData;

namespace UserDataModel.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        // Initialization of interface to call service methods.
        private IUserData _userData;

        public UsersController(IUserData userData)
        {
            _userData = userData;
        }

        //Calling Data Service "UserDataService" to Get all users.  
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetUsers()
        {
            return Ok(_userData.GetUsers());
        }

        //Calling Data Service "UserDataService" to Get a selected user based on Id.
        [HttpGet]
        [Route("api/[controller]/{Id}")]
        public IActionResult GetUser(int Id)
        {
            var user = _userData.GetUser(Id);

            if(user!= null)
            {
                return Ok(user);
            }

            return NotFound($"User with Id : {Id} was not found");
        }

        //Calling Data Service "UserDataService" to Add a new user.
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddUser(User user)
        {
             _userData.AddUser(user);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + user.Id, user);
            
        }

        //Calling Data Service "UserDataService" to Delete a selected User.
        [HttpDelete]
        [Route("api/[controller]/{Id}")]

        public IActionResult DeleteUser(int Id)
        {
            var user = _userData.GetUser(Id);

            if (user != null)
            {
                _userData.DeleteUser(user);
                return Ok($"user with Id : {Id} is deleted from Database");

            }

            return NotFound($"User with Id : {Id} was not found");

        }

        //Calling Data Service "UserDataService" to Update a selected existing User.
        [HttpPatch]
        [Route("api/[controller]/{Id}")]
        public IActionResult EditUser(int Id, User user)
        {
            var existingUser = _userData.GetUser(Id);

            if (existingUser != null)
            {
                user.Id = existingUser.Id;
                _userData.EditUser(user);
                return Ok(user);
            }

            return NotFound($"User with Id : {Id} was not found");
            
        }
    }
}
