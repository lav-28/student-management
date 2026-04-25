using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;

        //Foreign key
        [Required]
        public int CourseId { get; set; }

        //Navigation
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
