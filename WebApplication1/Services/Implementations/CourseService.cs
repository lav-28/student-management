using StudentManagement.DTOs;
using StudentManagement.Models;
using StudentManagement.Repository.Interfaces;
using StudentManagement.Services.Interfaces;

namespace StudentManagement.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public ServiceResponse<IEnumerable<CourseDto>> GetAllCourses()
        {
            var response = new ServiceResponse<IEnumerable<CourseDto>>();
            try
            {
                var courses = _courseRepository.GetAllCourses();
                if (courses != null && courses.Any())
                {
                    List<CourseDto> courseDtos = new List<CourseDto>();
                    foreach (var course in courses)
                    {
                        courseDtos.Add(new CourseDto
                        {
                            CourseId = course.CourseId,
                            CourseName = course.CourseName,
                            Credits = course.Credits
                        });
                    }
                    response.Data = courseDtos;
                    response.Message = "Courses retrieved successfully.";
                    response.Success = true;
                }
                else
                {
                    response.Message = "No courses found.";
                    response.Success = false;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error retrieving courses: {ex.Message}";
            }
            return response;
        }

        public ServiceResponse<CourseDto> GetCourseById(int id)
        {
            var response = new ServiceResponse<CourseDto>();
            try
            {
                var course = _courseRepository.GetCourseById(id).FirstOrDefault();
                if (course != null)
                {
                    response.Data = new CourseDto
                    {
                        CourseId = course.CourseId,
                        CourseName = course.CourseName,
                        Credits = course.Credits
                    };
                    response.Message = "Course retrieved successfully.";
                    response.Success = true;
                }
                else
                {
                    response.Message = "Course not found.";
                    response.Success = false;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error retrieving course: {ex.Message}";
            }
            return response;
        }

        public ServiceResponse<bool> AddCourse(AddCourseDto addCourseDto)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                if (_courseRepository.CourseExists(addCourseDto.CourseName))
                {
                    response.Message = "Course with the same name already exists.";
                    response.Success = false;
                    return response;
                }

                var course = new Course
                {
                    CourseName = addCourseDto.CourseName,
                    Credits = addCourseDto.Credits
                };

                var result = _courseRepository.AddCourse(course);
                if (result)
                {
                    response.Data = true;
                    response.Message = "Course added successfully.";
                    response.Success = true;
                }
                else
                {
                    response.Data = false;
                    response.Message = "Failed to add course data.";
                    response.Success = false;
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error adding course: {ex.Message}";
            }
            return response;
        }

        public ServiceResponse<bool> UpdateCourse(UpdateCourseDto updateCourseDto)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                if (_courseRepository.CourseExists(updateCourseDto.CourseId, updateCourseDto.CourseName))
                {
                    response.Message = "Course with the same name already exists.";
                    response.Success = false;
                    return response;
                }

                var result = false;
                var existingCourse = _courseRepository.GetCourseById(updateCourseDto.CourseId).FirstOrDefault();
                if (existingCourse == null)
                {
                    response.Message = "Course not found.";
                    response.Success = false;
                    return response;
                }
                if (existingCourse != null)
                {
                    existingCourse.CourseName = updateCourseDto.CourseName;
                    existingCourse.Credits = updateCourseDto.Credits;

                    result = _courseRepository.UpdateCourse(existingCourse);
                }
                if (result)
                {
                    response.Data = true;
                    response.Message = "Course updated successfully.";
                    response.Success = true;
                }
                else
                {
                    response.Data = false;
                    response.Message = "Failed to update course data.";
                    response.Success = false;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error updating course: {ex.Message}";
            }
            return response;
        }

        public ServiceResponse<bool> DeleteCourse(int courseId)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var result = _courseRepository.DeleteCourse(courseId);
                if (result)
                {
                    response.Data = true;
                    response.Message = "Course deleted successfully.";
                    response.Success = true;
                }
                else
                {
                    response.Data = false;
                    response.Message = "No course data found to delete.";
                    response.Success = false;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error deleting course: {ex.Message}";
            }
            return response;
        }
    }
}
