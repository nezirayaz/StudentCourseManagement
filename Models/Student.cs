using System.ComponentModel.DataAnnotations;

namespace StudentCourseManagement.Models
{
    /// <summary>
    /// Represents a student in the system
    /// </summary>
    public class Student : Person, ILogin
    {
        [Required(ErrorMessage = "Student number is required")]
        [RegularExpression(@"^\d{6,10}$", ErrorMessage = "Student number must be between 6 and 10 digits")]
        [Display(Name = "Student Number")]
        public string StudentNumber { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Display(Name = "Email Address")]
        public string? Email { get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Student: {FullName}, Number: {StudentNumber}");
        }

        public void Login()
        {
            Console.WriteLine($"{FullName} logged in as a student.");
        }
    }
}
