using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class Course
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
