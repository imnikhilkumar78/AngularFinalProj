using Angular_Final_Proj.Models;
using Angular_Final_Proj.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Angular_Final_Proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService _service;
        public DepartmentController(DepartmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<DepartmentModel> Get()
        {
            if (_service.GetAlldepartment() != null)
            {
                return _service.GetAlldepartment();
            }
            return null;
        }
        [HttpGet("{id}")]

        public DepartmentModel Get(int id)
        {
            if (_service.Getdepartment(id) != null)
            {
                return _service.Getdepartment(id);
            }
            return null;
        }
        [HttpPost]
        public async Task<ActionResult<DepartmentModel>> Post([FromBody] DepartmentModel department)
        {
            var deparmentdto = _service.Registerdepartment(department);
            if (deparmentdto != null)
                return deparmentdto;
            return BadRequest("Not able to Register");
        }
        [Route("UpdateDepartment")]
        [HttpPost]
        public ActionResult<DepartmentModel> Update([FromBody] DepartmentModel department)
        {
            var deparmentdto = _service.Updatedepartment(department);
            if (deparmentdto != null)
                return Ok(deparmentdto);
            return BadRequest("Not Working");

        }

        [HttpDelete]
        [Route("DeleteDepartment")]
        //[HttpDelete("{id}")]
        public JsonResult Deletedepartment(int id)
        {
            var result = _service.Deletedepartment(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
