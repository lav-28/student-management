using StudentManagement.DTOs;
using StudentManagement.Models;
using StudentManagement.Repository.Interfaces;
using StudentManagement.Services.Interfaces;

namespace StudentManagement.Services.Implementations
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentRepository _studentRepository;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository, ICourseRepository courseRepository, IStudentRepository studentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
        }

        public ServiceResponse<bool> EnrollStudent(EnrollStudentDto enrollStudentDto)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var studentExists = _studentRepository.GetStudentById(enrollStudentDto.StudentId).Any();
                if (!studentExists)
                {
                    response.Message = "Student not found.";
                    response.Success = false;
                    return response;
                }
                var courseExists = _courseRepository.GetCourseById(enrollStudentDto.CourseId).Any();
                if (!courseExists)
                {
                    response.Message = "Course not found.";
                    response.Success = false;
                    return response;
                }

                if (_enrollmentRepository.IsStudentEnrolled(enrollStudentDto.StudentId, enrollStudentDto.CourseId))
                {
                    response.Message = "Student is already enrolled in this course.";
                    response.Success = false;
                    return response;
                }

                var newEnrollment = new Enrollment
                {
                    StudentId = enrollStudentDto.StudentId,
                    CourseId = enrollStudentDto.CourseId,
                };

                var result = _enrollmentRepository.EnrollStudent(newEnrollment);
                if (result)
                {
                    response.Data = true;
                    response.Message = "Student enrolled successfully.";
                    response.Success = true;
                }
                else
                {
                    response.Data = false;
                    response.Message = "Failed to enroll student.";
                    response.Success = false;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error enrolling student: {ex.Message}";
            }
            return response;
        }

        public ServiceResponse<IEnumerable<EnrollmentDto>> GetEnrollmentsByCourseId(int courseId)
        {
            var response = new ServiceResponse<IEnumerable<EnrollmentDto>>();
            try
            {
                var courseExists = _courseRepository.GetCourseById(courseId).Any();
                if (!courseExists)
                {
                    response.Message = "Course not found.";
                    response.Success = false;
                    return response;
                }

                var enrollments = _enrollmentRepository.GetAllEnrollmentsbyCourseId(courseId);
                if (enrollments != null && enrollments.Any())
                {
                    var enrollmentDtos = new List<EnrollmentDto>();
                    foreach (var enrollment in enrollments)
                    {
                        enrollmentDtos.Add(new EnrollmentDto
                        {
                            EnrollmentId = enrollment.EnrollmentId,
                            StudentId = enrollment.StudentId,
                            CourseId = enrollment.CourseId,
                            EnrollmentDate = enrollment.EnrollmentDate,
                            Student = new Student()
                            {
                                StudentId = enrollment.Student.StudentId,
                                FirstName = enrollment.Student.FirstName,
                                LastName = enrollment.Student.LastName,
                                Email = enrollment.Student.Email,
                                Age = enrollment.Student.Age
                            },
                            Course = new Course()
                            {
                                CourseId = enrollment.Course.CourseId,
                                CourseName = enrollment.Course.CourseName,
                                Credits = enrollment.Course.Credits
                            }
                        });
                    }
                    response.Data = enrollmentDtos;
                    response.Message = "Enrollments retrieved successfully.";
                    response.Success = true;

                }
                else
                {
                    response.Message = "No enrollments found for this course.";
                    response.Success = false;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error retrieving enrollments: {ex.Message}";
            }
            return response;
        }

        public ServiceResponse<IEnumerable<EnrollmentDto>> GetEnrollmentsByStudentId(int studentId)
        {
            var response = new ServiceResponse<IEnumerable<EnrollmentDto>>();
            try
            {
                var studentExists = _studentRepository.GetStudentById(studentId).Any();
                if (!studentExists)
                {
                    response.Message = "Student not found.";
                    response.Success = false;
                    return response;
                }
                var enrollments = _enrollmentRepository.GetAllEnrollmentsbyStudentId(studentId);
                if (enrollments != null && enrollments.Any())
                {
                    var enrollmentDtos = new List<EnrollmentDto>();
                    foreach (var enrollment in enrollments)
                    {
                        enrollmentDtos.Add(new EnrollmentDto
                        {
                            EnrollmentId = enrollment.EnrollmentId,
                            StudentId = enrollment.StudentId,
                            CourseId = enrollment.CourseId,
                            EnrollmentDate = enrollment.EnrollmentDate,
                            Student = new Student()
                            {
                                StudentId = enrollment.Student.StudentId,
                                FirstName = enrollment.Student.FirstName,
                                LastName = enrollment.Student.LastName,
                                Email = enrollment.Student.Email,
                                Age = enrollment.Student.Age
                            },
                            Course = new Course()
                            {
                                CourseId = enrollment.Course.CourseId,
                                CourseName = enrollment.Course.CourseName,
                                Credits = enrollment.Course.Credits
                            }
                        });
                    }
                    response.Data = enrollmentDtos;
                    response.Message = "Enrollments retrieved successfully.";
                    response.Success = true;

                }
                else
                {
                    response.Message = "No enrollments found for this student.";
                    response.Success = false;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error retrieving enrollments: {ex.Message}";
            }
            return response;
        }

        public ServiceResponse<bool> UnenrollStudent(int studentId, int courseId)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var studentExists = _studentRepository.GetStudentById(studentId).Any();
                if (!studentExists)
                {
                    response.Message = "Student not found.";
                    response.Success = false;
                    return response;
                }
                var courseExists = _courseRepository.GetCourseById(courseId).Any();
                if (!courseExists)
                {
                    response.Message = "Course not found.";
                    response.Success = false;
                    return response;
                }

                if (!_enrollmentRepository.IsStudentEnrolled(studentId, courseId))
                {
                    response.Message = "Student is not enrolled in this course.";
                    response.Success = false;
                    return response;
                }


                var result = _enrollmentRepository.UnenrollStudent(studentId, courseId);
                if (result)
                {
                    response.Data = true;
                    response.Message = "Student unenrolled successfully.";
                    response.Success = true;
                }
                else
                {
                    response.Data = false;
                    response.Message = "Failed to unenroll student.";
                    response.Success = false;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error unenrolling student: {ex.Message}";
            }
            return response;
        }
    }
}
