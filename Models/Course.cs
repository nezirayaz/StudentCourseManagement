using System.ComponentModel.DataAnnotations;

namespace StudentCourseManagement.Models
{
    /// <summary>
    /// Represents a course in the system
    /// </summary>
    public class Course
    {
        private static int _nextId = 1;

        public Course()
        {
            Id = _nextId++;
            EnrolledStudents = new List<Student>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Course code is required")]
        [RegularExpression(@"^[A-Z]{2,4}\d{3}$", ErrorMessage = "Course code must be 2-4 uppercase letters followed by 3 digits (e.g., CS101)")]
        [Display(Name = "Course Code")]
        public string CourseCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Course name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Course name must be between 3 and 100 characters")]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Credits are required")]
        [Range(1, 10, ErrorMessage = "Credits must be between 1 and 10")]
        [Display(Name = "Credits")]
        public int Credits { get; set; }

        [Display(Name = "Instructor")]
        public Instructor? Instructor { get; set; }

        public int? InstructorId { get; set; }

        public List<Student> EnrolledStudents { get; set; }

        /// <summary>
        /// Enroll a student in the course
        /// </summary>
        public void EnrollStudent(Student student)
        {
            if (!EnrolledStudents.Any(s => s.Id == student.Id))
            {
                EnrolledStudents.Add(student);
            }
        }

        /// <summary>
        /// Display course information including enrolled students
        /// </summary>
        public void DisplayCourseInfo()
        {
            Console.WriteLine($"Course: {CourseCode} - {CourseName}, Credits: {Credits}");
            Console.WriteLine($"Instructor: {Instructor?.FullTitle ?? "Not assigned"}");
            Console.WriteLine($"Enrolled Students ({EnrolledStudents.Count}):");
            foreach (var student in EnrolledStudents)
            {
                Console.WriteLine($"  - {student.FullName} ({student.StudentNumber})");
            }
        }
    }
}
