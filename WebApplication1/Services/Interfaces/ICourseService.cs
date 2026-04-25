using StudentManagement.DTOs;

namespace StudentManagement.Services.Interfaces
{
    public interface ICourseService
    {
        ServiceResponse<IEnumerable<CourseDto>> GetAllCourses();
        ServiceResponse<CourseDto> GetCourseById(int id);
        ServiceResponse<bool> AddCourse(AddCourseDto courseDto);
        ServiceResponse<bool> UpdateCourse(UpdateCourseDto courseDto);
        ServiceResponse<bool> DeleteCourse(int courseId);
    }
}
