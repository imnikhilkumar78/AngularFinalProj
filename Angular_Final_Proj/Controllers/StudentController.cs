using Angular_Final_Proj.Models;
using Angular_Final_Proj.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Angular_Final_Proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _service;
        public StudentController(StudentService service) {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<StudentModel> Get()
        {
            if (_service.GetAll() != null)
            {
                return _service.GetAll();
            }
            return null;
        }
        [HttpGet("{id}")]

        public StudentModel Get(int id)
        {
            if (_service.GetStudent(id) != null)
            {
                return _service.GetStudent(id);
            }
            return null;
        }
        [HttpPost]
        public async Task<ActionResult<StudentDTO>> Post([FromBody] StudentDTO student)
        {
            var studentDTO = _service.Register(student);
            if (studentDTO != null)
                return studentDTO;
            return BadRequest("Not able to Register");
        }
        [Route("Update")]
        [HttpPost]
        public ActionResult<StudentDTO> Update([FromBody] StudentDTO student)
        {
            var studentDTO = _service.Update(student);
            if (studentDTO != null)
                return Ok(studentDTO);
            return BadRequest("Not Working");

        }

        [HttpDelete]
        [Route("DeleteStudent")]
        //[HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var result = _service.DeleteStudent(id);
            return new JsonResult("Deleted Successfully");
        }

    }
}
