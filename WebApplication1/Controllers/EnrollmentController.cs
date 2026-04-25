using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.DTOs;
using StudentManagement.Services.Interfaces;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpPost("EnrollStudent")]
        public IActionResult EnrollStudent([FromBody] EnrollStudentDto enrollStudentDto)
        {
            var result = _enrollmentService.EnrollStudent(enrollStudentDto);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("GetEnrollmentsByCourseId/{courseId}")]
        public IActionResult GetEnrollmentsByCourseId(int courseId)
        {
            var result = _enrollmentService.GetEnrollmentsByCourseId(courseId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [HttpGet("GetEnrollmentsByStudentId/{studentId}")]
        public IActionResult GetEnrollmentsByStudentId(int studentId)
        {
            var result = _enrollmentService.GetEnrollmentsByStudentId(studentId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [HttpDelete("UnenrollStudent")]
        public IActionResult UnenrollStudent(int studentId, int courseId)
        {
            var result = _enrollmentService.UnenrollStudent(studentId, courseId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
