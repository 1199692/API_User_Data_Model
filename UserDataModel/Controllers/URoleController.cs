using System;
using Microsoft.AspNetCore.Mvc;
using URoleDataModel.Models;
using URoleDataModel.URoleData;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace URoleDataModel.Controllers
{
    [ApiController]
    public class URoleController : ControllerBase
    {
        // Initialization of interface to call service methods.
        private IURoleData _uRoleData;

        public URoleController(IURoleData uRoleData)
        {
            _uRoleData = uRoleData;
        }

        //Calling Data Service "URoleDataService" to Get all User Roles. 
        [HttpGet]
        [Route("api/[controller]")]

        public IActionResult GetURoles()
        {
            return Ok(_uRoleData.GetURoles());
        }

        //Calling Data Service "URoleDataService" to Get a selected uRole based on Id.
        [HttpGet]
        [Route("api/[controller]/{Id}")]

        public IActionResult GetURole(int Id)
        {
            var uRole = _uRoleData.GetURole(Id);

            if (uRole != null)
            {
                return Ok(uRole);
            }

            return NotFound($"URole with Id : {Id} was not found");
        }

        //Calling Data Service "URoleDataService" to Adding a new uRole.
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddURole(URole uRole)
        {
            _uRoleData.AddURole(uRole);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + uRole.Id, uRole);
        }

        //Calling Data Service "URoleDataService" to Delete a given uRole
        [HttpDelete]
        [Route("api/[controller]/{Id}")]

        public IActionResult DeleteURole(int Id)
        {
            var uRole = _uRoleData.GetURole(Id);

            if (uRole != null)
            {
                _uRoleData.DeleteURole(uRole);
                return Ok();

            }

            return NotFound($"URole with Id : {Id} was not found");

        }

        //Calling Data Service "URoleDataService" to (update or modify) a given uRole.
        [HttpPatch]
        [Route("api/[controller]/{Id}")]
        public IActionResult EditURole(int Id, URole uRole)
        {
            var existingURole = _uRoleData.GetURole(Id);

            if (existingURole != null)
            {

                uRole.Id = existingURole.Id;
                _uRoleData.EditURole(uRole);
                return Ok(uRole);

            }
            return NotFound($"URole with Id : {Id} was not found");

        }
    }
}
