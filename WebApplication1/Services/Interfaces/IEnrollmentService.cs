using StudentManagement.DTOs;

namespace StudentManagement.Services.Interfaces
{
    public interface IEnrollmentService
    {
        ServiceResponse<bool> EnrollStudent(EnrollStudentDto enrollStudentDto);
        ServiceResponse<IEnumerable<EnrollmentDto>> GetEnrollmentsByCourseId(int courseId);
        ServiceResponse<IEnumerable<EnrollmentDto>> GetEnrollmentsByStudentId(int studentId);
        ServiceResponse<bool> UnenrollStudent(int studentId, int courseId);
    }
}
