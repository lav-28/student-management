using System.ComponentModel.DataAnnotations;

namespace StudentManagement.DTOs
{
    public class EnrollStudentDto
    {
        [Required(ErrorMessage = "StudentId is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "StudentId cannot be negative")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "CourseId is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "CourseId cannot be negative")]
        public int CourseId { get; set; }
    }
}
