using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.DTOs;
using StudentManagement.Services.Interfaces;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("GetAllCourses")]
        public IActionResult GetAllCourses()
        {
            var response = _courseService.GetAllCourses();
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }

        [HttpGet("GetCourseById/{id}")]
        public IActionResult GetCourseById(int id)
        {
            var response = _courseService.GetCourseById(id);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }

        [HttpPost("AddCourse")]
        public IActionResult AddCourse([FromBody] AddCourseDto courseDto)
        {
            var response = _courseService.AddCourse(courseDto);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPut("UpdateCourse")]
        public IActionResult UpdateCourse([FromBody] UpdateCourseDto courseDto)
        {
            var response = _courseService.UpdateCourse(courseDto);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpDelete("DeleteCourse/{courseId}")]
        public IActionResult DeleteCourse(int courseId)
        {
            var response = _courseService.DeleteCourse(courseId);
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
