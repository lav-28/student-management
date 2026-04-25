using StudentManagement.Data;
using StudentManagement.Models;
using StudentManagement.Repository.Interfaces;

namespace StudentManagement.Repository.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _appDbContext;

        public StudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            var students = _appDbContext.Students.ToList();
            return students;
        }

        public IEnumerable<Student> GetStudentById(int id)
        {
            var student = _appDbContext.Students.Where(s => s.StudentId == id).ToList();
            return student;
        }

        public bool AddStudent(Student student)
        {
            var result = false;
            if (student != null)
            {
                _appDbContext.Students.Add(student);
                _appDbContext.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool UpdateStudent(Student student)
        {
            var result = false;
            if (student != null)
            {
                _appDbContext.Students.Update(student);
                _appDbContext.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool DeleteStudent(int studentId)
        {
            var result = false;
            var student = _appDbContext.Students.FirstOrDefault(s => s.StudentId == studentId);
            if (student != null)
            {
                _appDbContext.Students.Remove(student);
                _appDbContext.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool StudentExists(string emailAddress )
        {
            var student = _appDbContext.Students.Any(s => s.Email == emailAddress);
            if (student)
            {
                return true;
            }
            return false;
        }

        public bool StudentExists(int id, string emailAddress)
        {
            var student = _appDbContext.Students.Any(s => s.StudentId != id && s.Email == emailAddress);
            if (student)
            {
                return true;
            }
            return false;
        }
    }
}
