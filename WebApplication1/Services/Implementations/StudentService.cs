using StudentManagement.DTOs;
using StudentManagement.Models;
using StudentManagement.Repository.Interfaces;
using StudentManagement.Services.Interfaces;

namespace StudentManagement.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public ServiceResponse<IEnumerable<StudentDto>> GetAllStudents()
        {
            var response = new ServiceResponse<IEnumerable<StudentDto>>();
            try
            {
                var students = _studentRepository.GetAllStudents();
                if (students != null && students.Any())
                {
                    List<StudentDto> studentDtos = new List<StudentDto>();
                    foreach (var student in students)
                    {
                        studentDtos.Add(new StudentDto
                        {
                            StudentId = student.StudentId,
                            FirstName = student.FirstName,
                            LastName = student.LastName,
                            Email = student.Email,
                            Age = student.Age
                        });
                    }
                    response.Data = studentDtos;
                    response.Message = "Students retrieved successfully.";
                    response.Success = true;
                }
                else
                {
                    response.Message = "No students found.";
                    response.Success = false;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error retrieving students: {ex.Message}";
            }
            return response;
        }

        public ServiceResponse<StudentDto> GetStudentById(int id)
        {
            var response = new ServiceResponse<StudentDto>();
            try
            {
                var student = _studentRepository.GetStudentById(id).FirstOrDefault();
                if (student != null)
                {
                    var studentDto = new StudentDto
                    {
                        StudentId = student.StudentId,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        Email = student.Email,
                        Age = student.Age
                    };
                    response.Data = studentDto;
                    response.Message = "Student retrieved successfully.";
                    response.Success = true;
                }
                else
                {
                    response.Message = "Student not found.";
                    response.Success = false;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error retrieving student: {ex.Message}";
            }
            return response;
        }

        public ServiceResponse<string> AddStudent(AddStudentDto addStudentDto)
        {
            var response = new ServiceResponse<string>();
            try
            {
                if (_studentRepository.StudentExists(addStudentDto.Email))
                {
                    response.Success = false;
                    response.Message = "A student with this email already exists.";
                    return response;
                }
                var student = new Student
                {
                    FirstName = addStudentDto.FirstName,
                    LastName = addStudentDto.LastName,
                    Email = addStudentDto.Email,
                    Age = addStudentDto.Age
                };

                var result = _studentRepository.AddStudent(student);

                if (result)
                {
                    response.Success = true;
                    response.Message = "Student added successfully.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Failed to add student.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error checking student existence: {ex.Message}";
                return response;
            }
            return response;
        }

        public ServiceResponse<string> UpdateStudent(UpdateStudentDto updateStudentDto)
        {
            var response = new ServiceResponse<string>();
            try
            {
                if (_studentRepository.StudentExists(updateStudentDto.StudentId, updateStudentDto.Email))
                {
                    response.Success = false;
                    response.Message = "Student with email already exists.";
                    return response;
                }

                var result = false;
                var existingStudent = _studentRepository.GetStudentById(updateStudentDto.StudentId).FirstOrDefault();
                if (existingStudent == null)
                {
                    response.Success = false;
                    response.Message = "Student not found.";
                    return response;
                }

                if (existingStudent != null)
                {
                    existingStudent.FirstName = updateStudentDto.FirstName;
                    existingStudent.LastName = updateStudentDto.LastName;
                    existingStudent.Email = updateStudentDto.Email;
                    existingStudent.Age = updateStudentDto.Age;

                    result = _studentRepository.UpdateStudent(existingStudent);
                }

                if (result)
                {
                    response.Success = true;
                    response.Message = "Student updated successfully.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Failed to update student.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error updating student: {ex.Message}";
                return response;
            }
            return response;
        }

        public ServiceResponse<string> DeleteStudent(int id)
        {
            var response = new ServiceResponse<string>();
            try
            {
               var result = _studentRepository.DeleteStudent(id);
                if (result)
                {
                    response.Success = true;
                    response.Message = "Student deleted successfully.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "No student found to delete.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error deleting student: {ex.Message}";
                return response;
            }
            return response;
        }
    }
}
