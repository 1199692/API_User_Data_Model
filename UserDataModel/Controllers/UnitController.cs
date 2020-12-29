using Microsoft.AspNetCore.Mvc;
using UnitDataModel.Models;
using UnitDataModel.UnitData;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UnitDataModel.Controllers
{
    [ApiController]
    public class UnitController : ControllerBase
    {
        // Initialization of interface to call service methods.
        private IUnitData _unitData;

        public UnitController(IUnitData unitData)
        {
            _unitData = unitData;
        }

        //Calling Data Service "UnitDataService" to Get all units. 
        [HttpGet]
        [Route("api/[controller]")]

        public IActionResult GetUnits()
        {
            return Ok(_unitData.GetUnits());
        }

        //Calling Data Service "UnitDataService" to Get a selected unit based on Id.
        [HttpGet]
        [Route("api/[controller]/{Id}")]

        public IActionResult GetUnit(int Id)
        {
            var unit = _unitData.GetUnit(Id);

            if (unit != null)
            {
                return Ok(unit);
            }

            return NotFound($"Unit with Id : {Id} was not found");
        }

        //Calling Data Service "UnitDataService" to Adding a new unit.
        [HttpPost]
        [Route("api/[controller]")]

        public IActionResult AddUnit(Unit unit)
        {
            _unitData.AddUnit(unit);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + unit.Id, unit);

        }

        //Calling Data Service "UnitDataService" to Delete a given unit
        [HttpDelete]
        [Route("api/[controller]/{Id}")]

        public IActionResult DeleteUnit(int Id)
        {
            var unit = _unitData.GetUnit(Id);

            if (unit != null)
            {
                _unitData.DeleteUnit(unit);
                return Ok();

            }

            return NotFound($"Unit with Id : {Id} was not found");

        }

        //Calling Data Service "UnitDataService" to (update or modify) a given unit.
        [HttpPatch]
        [Route("api/[controller]/{Id}")]
        public IActionResult EditUnit(int Id,Unit unit)
        {
            var existingUnit = _unitData.GetUnit(Id);

            if (existingUnit != null)
            {

                unit.Id = existingUnit.Id;
                _unitData.EditUnit(unit);
                return Ok(unit);

            }
            return NotFound($"Unit with Id : {Id} was not found");

        }
    }
}
