using StudentManagement.DTOs;

namespace StudentManagement.Services.Interfaces
{
    public interface IStudentService
    {
        ServiceResponse<IEnumerable<StudentDto>> GetAllStudents();
        ServiceResponse<StudentDto> GetStudentById(int id);
        ServiceResponse<string> AddStudent(AddStudentDto studentDto);
        ServiceResponse<string> UpdateStudent(UpdateStudentDto updateStudentDto);
        ServiceResponse<string> DeleteStudent(int id);
    }
}
