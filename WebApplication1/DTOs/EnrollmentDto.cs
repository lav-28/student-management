using System.ComponentModel.DataAnnotations;
using StudentManagement.Models;

namespace StudentManagement.DTOs
{
    public class EnrollmentDto
    {
        public int EnrollmentId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;

        //Foreign key
        [Required]
        public int CourseId { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
