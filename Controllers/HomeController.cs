using Microsoft.AspNetCore.Mvc;
using StudentCourseManagement.Models;
using System.Diagnostics;

namespace StudentCourseManagement.Controllers
{
    public class HomeController : Controller
    {
        // Static lists to simulate database (in production, use a real database)
        private static List<Student> _students = new List<Student>();
        private static List<Instructor> _instructors = new List<Instructor>();
        private static List<Course> _courses = new List<Course>();
        private static readonly object _lock = new object();
        private static bool _isInitialized = false;

        public HomeController()
        {
            // Initialize sample data on first access
            if (!_isInitialized)
            {
                lock (_lock)
                {
                    if (!_isInitialized)
                    {
                        InitializeSampleData();
                        _isInitialized = true;
                    }
                }
            }
        }

        private void InitializeSampleData()
        {
            // Add sample students
            _students.Add(new Student
            {
                FirstName = "John",
                LastName = "Doe",
                StudentNumber = "20230001",
                Email = "john.doe@university.edu"
            });

            _students.Add(new Student
            {
                FirstName = "Jane",
                LastName = "Smith",
                StudentNumber = "20230002",
                Email = "jane.smith@university.edu"
            });

            _students.Add(new Student
            {
                FirstName = "Michael",
                LastName = "Johnson",
                StudentNumber = "20230003",
                Email = "michael.j@university.edu"
            });

            _students.Add(new Student
            {
                FirstName = "Emily",
                LastName = "Brown",
                StudentNumber = "20230004",
                Email = "emily.brown@university.edu"
            });

            // Add sample instructors
            _instructors.Add(new Instructor
            {
                FirstName = "Robert",
                LastName = "Williams",
                Title = "Professor",
                Department = "Computer Science",
                Email = "r.williams@university.edu"
            });

            _instructors.Add(new Instructor
            {
                FirstName = "Sarah",
                LastName = "Davis",
                Title = "Associate Professor",
                Department = "Mathematics",
                Email = "s.davis@university.edu"
            });

            _instructors.Add(new Instructor
            {
                FirstName = "David",
                LastName = "Miller",
                Title = "Assistant Professor",
                Department = "Physics",
                Email = "d.miller@university.edu"
            });

            // Add sample courses
            var course1 = new Course
            {
                CourseCode = "CS101",
                CourseName = "Introduction to Programming",
                Credits = 4,
                Instructor = _instructors[0],
                InstructorId = _instructors[0].Id
            };
            course1.EnrollStudent(_students[0]);
            course1.EnrollStudent(_students[1]);
            _courses.Add(course1);

            var course2 = new Course
            {
                CourseCode = "MATH201",
                CourseName = "Calculus II",
                Credits = 3,
                Instructor = _instructors[1],
                InstructorId = _instructors[1].Id
            };
            course2.EnrollStudent(_students[1]);
            course2.EnrollStudent(_students[2]);
            _courses.Add(course2);

            var course3 = new Course
            {
                CourseCode = "PHY101",
                CourseName = "General Physics",
                Credits = 4,
                Instructor = _instructors[2],
                InstructorId = _instructors[2].Id
            };
            course3.EnrollStudent(_students[0]);
            course3.EnrollStudent(_students[3]);
            _courses.Add(course3);

            var course4 = new Course
            {
                CourseCode = "CS202",
                CourseName = "Data Structures and Algorithms",
                Credits = 4,
                Instructor = _instructors[0],
                InstructorId = _instructors[0].Id
            };
            course4.EnrollStudent(_students[2]);
            _courses.Add(course4);
        }

        public IActionResult Index()
        {
            ViewBag.StudentCount = _students.Count;
            ViewBag.InstructorCount = _instructors.Count;
            ViewBag.CourseCount = _courses.Count;
            return View();
        }

        // Student Actions
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                lock (_lock)
                {
                    _students.Add(student);
                }
                TempData["SuccessMessage"] = $"Student {student.FullName} added successfully!";
                return RedirectToAction("ListStudents");
            }
            return View(student);
        }

        public IActionResult ListStudents()
        {
            return View(_students);
        }

        // Instructor Actions
        [HttpGet]
        public IActionResult AddInstructor()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddInstructor(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                lock (_lock)
                {
                    _instructors.Add(instructor);
                }
                TempData["SuccessMessage"] = $"Instructor {instructor.FullTitle} added successfully!";
                return RedirectToAction("ListInstructors");
            }
            return View(instructor);
        }

        public IActionResult ListInstructors()
        {
            return View(_instructors);
        }

        // Course Actions
        [HttpGet]
        public IActionResult AddCourse()
        {
            ViewBag.Instructors = _instructors;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                lock (_lock)
                {
                    if (course.InstructorId.HasValue)
                    {
                        course.Instructor = _instructors.FirstOrDefault(i => i.Id == course.InstructorId.Value);
                    }
                    _courses.Add(course);
                }
                TempData["SuccessMessage"] = $"Course {course.CourseCode} - {course.CourseName} added successfully!";
                return RedirectToAction("ListCourses");
            }
            ViewBag.Instructors = _instructors;
            return View(course);
        }

        public IActionResult ListCourses()
        {
            return View(_courses);
        }

        [HttpGet]
        public IActionResult CourseDetails(int id)
        {
            var course = _courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpGet]
        public IActionResult EnrollStudent(int courseId)
        {
            var course = _courses.FirstOrDefault(c => c.Id == courseId);
            if (course == null)
            {
                return NotFound();
            }
            ViewBag.Course = course;
            ViewBag.Students = _students;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EnrollStudent(int courseId, int studentId)
        {
            var course = _courses.FirstOrDefault(c => c.Id == courseId);
            var student = _students.FirstOrDefault(s => s.Id == studentId);

            if (course == null || student == null)
            {
                return NotFound();
            }

            lock (_lock)
            {
                course.EnrollStudent(student);
            }

            TempData["SuccessMessage"] = $"Student {student.FullName} enrolled in {course.CourseCode} successfully!";
            return RedirectToAction("CourseDetails", new { id = courseId });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
