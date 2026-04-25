using StudentManagement.Models;

namespace StudentManagement.Repository.Interfaces
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAllCourses();
        IEnumerable<Course> GetCourseById(int id);
        bool AddCourse(Course course);
        bool UpdateCourse(Course course);
        bool DeleteCourse(int courseId);
        bool CourseExists(string courseName);
        bool CourseExists(int courseId, string courseName);
    }
}
