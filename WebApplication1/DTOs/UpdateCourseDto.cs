using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.DTOs
{
    public class UpdateCourseDto
    {
        [Required(ErrorMessage = "Course ID is required.")]
        [DisplayName(" ID")]
        [Range(1, int.MaxValue, ErrorMessage = "Student ID must be a positive integer.")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course name is required.")]
        [StringLength(100, ErrorMessage = "Course name cannot be longer than 100 characters.")]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Credits is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Credits cannot be negative.")]
        public int Credits { get; set; }
    }
}
