using StudentManagement.Models;

namespace StudentManagement.Repository.Interfaces
{
    public interface IEnrollmentRepository
    {
        bool EnrollStudent(Enrollment enrollment);
        IEnumerable<Enrollment> GetAllEnrollmentsbyCourseId(int courseId);
        IEnumerable<Enrollment> GetAllEnrollmentsbyStudentId(int studentId);
        bool IsStudentEnrolled(int studentId, int courseId);
        bool UnenrollStudent(int studentId, int courseId);
    }
}
