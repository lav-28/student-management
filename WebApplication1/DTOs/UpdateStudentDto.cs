using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StudentManagement.DTOs
{
    public class UpdateStudentDto
    {
        [Required(ErrorMessage = "Student ID is required.")]
        [DisplayName("Student ID")]
        [Range(1, int.MaxValue, ErrorMessage = "Student ID must be a positive integer.")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [DisplayName("First Name")]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [DisplayName("Last Name")]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [StringLength(50)]
        [EmailAddress]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email format.")]
        [DisplayName("Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Age cannot be negative")]
        public int Age { get; set; }
    }
}
