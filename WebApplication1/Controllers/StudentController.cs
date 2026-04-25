using Microsoft.AspNetCore.Mvc;
using StudentManagement.DTOs;
using StudentManagement.Services.Interfaces;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("GetAllStudents")]
        public IActionResult GetAllStudents()
        {
            var response = _studentService.GetAllStudents();
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }

        [HttpGet("GetStudentById/{id}")]
        public IActionResult GetStudentById(int id)
        {
            var response = _studentService.GetStudentById(id);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }

        [HttpPost("AddStudent")]
        public IActionResult AddStudent([FromBody] AddStudentDto studentDto)
        {
            var response = _studentService.AddStudent(studentDto);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPut("UpdateStudent")]
        public IActionResult UpdateStudent([FromBody] UpdateStudentDto updateStudentDto)
        {
            var response = _studentService.UpdateStudent(updateStudentDto);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpDelete("DeleteStudent/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var response = _studentService.DeleteStudent(id);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }
    }
}
