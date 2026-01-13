using System.ComponentModel.DataAnnotations;

namespace StudentCourseManagement.Models
{
    /// <summary>
    /// Represents an instructor/faculty member in the system
    /// </summary>
    public class Instructor : Person, ILogin
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(50, ErrorMessage = "Title cannot exceed 50 characters")]
        [Display(Name = "Academic Title")]
        public string Title { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Display(Name = "Email Address")]
        public string? Email { get; set; }

        [Display(Name = "Department")]
        public string? Department { get; set; }

        public string FullTitle => $"{Title} {FullName}";

        public override void DisplayInfo()
        {
            Console.WriteLine($"Instructor: {FullTitle}, Department: {Department ?? "N/A"}");
        }

        public void Login()
        {
            Console.WriteLine($"{FullTitle} logged in as an instructor.");
        }
    }
}
