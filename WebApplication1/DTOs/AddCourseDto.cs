using System.ComponentModel.DataAnnotations;

namespace StudentManagement.DTOs
{
    public class AddCourseDto
    {
        [Required(ErrorMessage = "Course name is required.")]
        [StringLength(100, ErrorMessage = "Course name cannot be longer than 100 characters.")]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Credits is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Credits cannot be negative.")]
        public int Credits { get; set; }
    }
}
