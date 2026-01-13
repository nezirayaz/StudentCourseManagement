using System.ComponentModel.DataAnnotations;

namespace StudentCourseManagement.Models
{
    /// <summary>
    /// Abstract base class representing a person in the system
    /// </summary>
    public abstract class Person
    {
        private static int _nextId = 1;

        public Person()
        {
            Id = _nextId++;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters")]
        public string LastName { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";

        /// <summary>
        /// Abstract method to display person information
        /// </summary>
        public abstract void DisplayInfo();
    }
}
