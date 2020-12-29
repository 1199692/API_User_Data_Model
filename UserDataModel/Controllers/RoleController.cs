using Microsoft.AspNetCore.Mvc;
using RoleDataModel.Models;
using RoleDataModel.RoleData;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RoleDataModel.Controllers
{
    [ApiController]
    public class RoleController : ControllerBase
    {
        // Initialization of interface to call service methods.
        private IRoleData _roleData;

        public RoleController(IRoleData roleData)
        {
            _roleData = roleData;
        }

        //Calling Data Service "RoleDataService" to Get all roles. 
        [HttpGet]
        [Route("api/[controller]")]

        public IActionResult GetRoles()
        {
            return Ok(_roleData.GetRoles());
        }

        //Calling Data Service "RoleDataService" to Get a selected role based on Id.
        [HttpGet]
        [Route("api/[controller]/{Id}")]

        public IActionResult GetRole(int Id)
        {
            var role = _roleData.GetRole(Id);

            if (role != null)
            {
                return Ok(role);
            }

            return NotFound($"Role with Id : {Id} was not found");
        }

        //Calling Data Service "RoleDataService" to Adding a new role.
        [HttpPost]
        [Route("api/[controller]")]

        public IActionResult AddRole(Role role)
        {
            _roleData.AddRole(role);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + role.Id, role);

        }

        //Calling Data Service "RoleDataService" to Delete a given role
        [HttpDelete]
        [Route("api/[controller]/{Id}")]

        public IActionResult DeleteRole(int Id)
        {
            var role = _roleData.GetRole(Id);

            if (role != null)
            {
                _roleData.DeleteRole(role);
                return Ok();

            }

            return NotFound($"Role with Id : {Id} was not found");

        }

        //Calling Data Service "RoleDataService" to (update or modify) a given role.
        [HttpPatch]
        [Route("api/[controller]/{Id}")]
        public IActionResult EditRole(int Id, Role role)
        {
            var existingRole = _roleData.GetRole(Id);

            if (existingRole != null)
            {

                role.Id = existingRole.Id;
                _roleData.EditRole(role);
                return Ok(role);

            }
            return NotFound($"Role with Id : {Id} was not found");

        }
    }
}
