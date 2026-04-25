using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Models;
using StudentManagement.Repository.Interfaces;

namespace StudentManagement.Repository.Implementations
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly AppDbContext _appDbContext;

        public EnrollmentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool EnrollStudent(Enrollment enrollment)
        {
            var result = false;
            {
                _appDbContext.Enrollments.Add(enrollment);
                _appDbContext.SaveChanges();
                result = true;
            }
            
            return result;
        }

        public IEnumerable<Enrollment> GetAllEnrollmentsbyCourseId(int courseId)
        {
            var enrollments = _appDbContext.Enrollments.Include(e => e.Student).Include(e => e.Course)
                                                  .Where(e => e.CourseId == courseId)
                                                  .ToList();
            return enrollments;
        }

        public IEnumerable<Enrollment> GetAllEnrollmentsbyStudentId(int studentId)
        {
            var enrollments = _appDbContext.Enrollments.Include(e => e.Course).Include(e => e.Student)
                                                  .Where(e => e.StudentId == studentId)
                                                  .ToList();
            return enrollments;
        }   

        public bool UnenrollStudent(int studentId, int courseId)
        {
            var result = false;
            var enrollment = _appDbContext.Enrollments.FirstOrDefault(e => e.StudentId == studentId && e.CourseId == courseId);
            if (enrollment != null)
            {
                _appDbContext.Enrollments.Remove(enrollment);
                _appDbContext.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool IsStudentEnrolled(int studentId, int courseId)
        {
            var result = _appDbContext.Enrollments.Any(e => e.StudentId == studentId && e.CourseId == courseId);
            if (result)
            {
                // Student is already enrolled in the course
                return true;
            }
            return false;
        }
    }
}
