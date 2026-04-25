using StudentManagement.Models;

namespace StudentManagement.Repository.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();
        IEnumerable<Student> GetStudentById(int id);
        bool AddStudent(Student student);
        bool UpdateStudent(Student student);
        bool DeleteStudent(int studentId);
        bool StudentExists(string emailAddress);
        bool StudentExists(int id, string emailAddress);
    }
}
