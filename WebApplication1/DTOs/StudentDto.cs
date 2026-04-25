using StudentManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.DTOs
{
    public class StudentDto
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int Age { get; set; }

        // Navigation
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
