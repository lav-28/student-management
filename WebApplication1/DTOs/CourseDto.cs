using System.ComponentModel.DataAnnotations;
using StudentManagement.Models;

namespace StudentManagement.DTOs
{
    public class CourseDto
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        public string CourseName { get; set; }

        [Required]
        public int Credits { get; set; }

        // Navigation
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
