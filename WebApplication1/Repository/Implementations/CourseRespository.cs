using StudentManagement.Data;
using StudentManagement.Models;
using StudentManagement.Repository.Interfaces;

namespace StudentManagement.Repository.Implementations
{
    public class CourseRespository : ICourseRepository
    {
        private readonly AppDbContext _appDbContext;

        public CourseRespository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            var courses = _appDbContext.Courses.ToList();
            return courses;
        }

        public IEnumerable<Course> GetCourseById(int id)
        {
            var course = _appDbContext.Courses.Where(c => c.CourseId == id).ToList();
            return course;
        }

        public bool AddCourse(Course course)
        {
            var result = false;
            if (course != null)
            {
                _appDbContext.Courses.Add(course);
                _appDbContext.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool UpdateCourse(Course course)
        {
            var result = false;
            if (course != null)
            {
                _appDbContext.Courses.Update(course);
                _appDbContext.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool DeleteCourse(int courseId)
        {
            var result = false;
            var course = _appDbContext.Courses.FirstOrDefault(c => c.CourseId == courseId);
            if (course != null)
            {
                _appDbContext.Courses.Remove(course);
                _appDbContext.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool CourseExists(string courseName)
        {
            var course = _appDbContext.Courses.Any(c => c.CourseName == courseName);
            if (course)
            {
                return true;
            }
            return false;
        }

        public bool CourseExists(int courseId, string courseName)
        {
            var course = _appDbContext.Courses.Any(c => c.CourseId != courseId && c.CourseName == courseName);
            if (course)
            {
                return true;
            }
            return false;
        }
    }
}
