# Student Course Management System

A modern, professional web application for managing students, instructors, and courses built with ASP.NET Core MVC.

## Overview

The **Student Course Management System** is a comprehensive web application designed to streamline the administration of academic institutions. Built with ASP.NET Core MVC (.NET 9.0), this system provides an intuitive interface for managing students, instructors, and courses while maintaining data integrity through robust validation.

This project demonstrates professional software development practices including clean architecture, proper naming conventions, responsive design, and user-friendly interfaces. The application comes pre-loaded with sample data to allow immediate exploration of all features.

## Key Features

### Student Management
- Add new students with validated information (name, student number, email)
- View comprehensive list of all registered students
- Automatic ID generation for each student
- Email validation to ensure proper contact information

### Instructor Management
- Register instructors with academic titles and departments
- Support for various academic ranks (Professor, Associate Professor, Assistant Professor, etc.)
- Department assignment for organizational structure
- Complete instructor directory with contact information

### Course Management
- Create courses with unique course codes (e.g., CS101, MATH201)
- Assign credit hours (1-10 credits)
- Link courses to specific instructors
- View detailed course information including enrolled students

### Student Enrollment
- Enroll students in available courses
- Prevent duplicate enrollments
- Track enrollment numbers per course
- View all students enrolled in each course

### User Interface
- Clean, modern design using Bootstrap 5
- Responsive layout that works on desktop, tablet, and mobile devices
- Intuitive navigation with organized menus
- Real-time success notifications for user actions
- Statistics dashboard showing system overview

### Data Validation
- Server-side validation for all input fields
- Format validation for student numbers and course codes
- Email address validation
- Required field enforcement
- Range validation for credit hours

## Technology Stack

| Component | Technology |
|-----------|-----------|
| **Framework** | ASP.NET Core MVC (.NET 9.0) |
| **Language** | C# 12 |
| **Frontend** | HTML5, CSS3, JavaScript (ES6+) |
| **UI Framework** | Bootstrap 5.3 |
| **Icons** | Bootstrap Icons 1.11 |
| **Architecture** | Model-View-Controller (MVC) |
| **Data Storage** | In-memory (static lists) |

## Project Structure

```
StudentCourseManagement/
│
├── Controllers/                    # Application logic and request handling
│   └── HomeController.cs          # Main controller with all CRUD operations
│
├── Models/                         # Data models and business logic
│   ├── Person.cs                  # Abstract base class for people
│   ├── Student.cs                 # Student model with validation
│   ├── Instructor.cs              # Instructor model with validation
│   ├── Course.cs                  # Course model with enrollment logic
│   ├── ILogin.cs                  # Login interface
│   └── ErrorViewModel.cs          # Error handling model
│
├── Views/                          # User interface templates
│   ├── Home/                      # Views for main functionality
│   │   ├── Index.cshtml           # Dashboard/home page
│   │   ├── AddStudent.cshtml      # Student registration form
│   │   ├── ListStudents.cshtml    # Student list view
│   │   ├── AddInstructor.cshtml   # Instructor registration form
│   │   ├── ListInstructors.cshtml # Instructor list view
│   │   ├── AddCourse.cshtml       # Course creation form
│   │   ├── ListCourses.cshtml     # Course list view
│   │   ├── CourseDetails.cshtml   # Detailed course information
│   │   └── EnrollStudent.cshtml   # Student enrollment form
│   │
│   ├── Shared/                    # Shared layout components
│   │   ├── _Layout.cshtml         # Main layout template
│   │   ├── _ValidationScriptsPartial.cshtml
│   │   └── Error.cshtml           # Error page
│   │
│   ├── _ViewStart.cshtml          # View initialization
│   └── _ViewImports.cshtml        # Global using statements
│
├── wwwroot/                        # Static files
│   ├── css/
│   │   └── site.css               # Custom styles
│   └── js/
│       └── site.js                # Custom JavaScript
│
├── Properties/
│   └── launchSettings.json        # Development server configuration
│
├── .gitignore                      # Git ignore rules
├── Program.cs                      # Application entry point
├── StudentCourseManagement.csproj  # Project configuration
├── appsettings.json               # Application settings
├── appsettings.Development.json   # Development settings
└── README.md                       # This file
```

## Getting Started

### Prerequisites

Before running this application, ensure you have the following installed:

- **.NET 9.0 SDK** or later - [Download here](https://dotnet.microsoft.com/download/dotnet/9.0)
- A code editor such as:
  - [Visual Studio 2022](https://visualstudio.microsoft.com/) (recommended for Windows)
  - [Visual Studio Code](https://code.visualstudio.com/) (cross-platform)
  - [JetBrains Rider](https://www.jetbrains.com/rider/) (cross-platform)

### Installation & Running

#### Option 1: Using Command Line

1. **Extract the project** to your desired location

2. **Open a terminal** and navigate to the project directory:
   ```bash
   cd StudentCourseManagement
   ```

3. **Restore NuGet packages**:
   ```bash
   dotnet restore
   ```

4. **Build the project**:
   ```bash
   dotnet build
   ```

5. **Run the application**:
   ```bash
   dotnet run
   ```

6. **Open your browser** and navigate to:
   - HTTPS: `https://localhost:5001`
   - HTTP: `http://localhost:5000`

#### Option 2: Using Visual Studio

1. **Open the solution** by double-clicking `StudentCourseManagement.csproj`
2. **Press F5** or click the **Run** button to start debugging
3. The application will automatically open in your default browser

#### Option 3: Using Visual Studio Code

1. **Open the project folder** in VS Code
2. **Open the terminal** (Ctrl+` or Cmd+`)
3. **Run the command**: `dotnet run`
4. **Open your browser** to `https://localhost:5001`

### First Time Usage

When you first run the application, it will automatically load with sample data including:

- **4 Students**: John Doe, Jane Smith, Michael Johnson, Emily Brown
- **3 Instructors**: Professor Robert Williams (Computer Science), Associate Professor Sarah Davis (Mathematics), Assistant Professor David Miller (Physics)
- **4 Courses**: CS101 (Introduction to Programming), MATH201 (Calculus II), PHY101 (General Physics), CS202 (Data Structures and Algorithms)

This sample data allows you to immediately explore all features without needing to manually enter data first.

## Usage Guide

### Dashboard

The home page displays a summary dashboard with:
- Total count of students, instructors, and courses
- Quick action buttons for common tasks
- Navigation cards for each management section

### Managing Students

1. Click **"Add Student"** from the dashboard or navigation menu
2. Fill in the required information:
   - First Name (2-50 characters)
   - Last Name (2-50 characters)
   - Student Number (6-10 digits, e.g., 20230001)
   - Email Address (optional, must be valid format)
3. Click **"Add Student"** to save
4. View all students by clicking **"List Students"**

### Managing Instructors

1. Click **"Add Instructor"** from the dashboard or navigation menu
2. Enter the instructor details:
   - Academic Title (e.g., Professor, Associate Professor)
   - First Name
   - Last Name
   - Department (optional)
   - Email Address (optional)
3. Click **"Add Instructor"** to save
4. View all instructors by clicking **"List Instructors"**

### Managing Courses

1. Click **"Add Course"** from the dashboard or navigation menu
2. Provide course information:
   - Course Code (format: 2-4 uppercase letters + 3 digits, e.g., CS101)
   - Course Name
   - Credits (1-10)
   - Select an Instructor from the dropdown
3. Click **"Add Course"** to save
4. View all courses by clicking **"List Courses"**

### Enrolling Students in Courses

1. Navigate to **"List Courses"**
2. Click **"View Details"** on any course
3. Click **"Enroll Student"** button
4. Select a student from the dropdown menu
5. Click **"Enroll Student"** to complete the enrollment
6. The student will now appear in the course's enrolled students list

## Data Validation Rules

The application enforces the following validation rules:

| Field | Rules |
|-------|-------|
| **First Name** | Required, 2-50 characters |
| **Last Name** | Required, 2-50 characters |
| **Student Number** | Required, 6-10 digits only |
| **Email** | Optional, must be valid email format |
| **Instructor Title** | Required, max 50 characters |
| **Course Code** | Required, format: 2-4 uppercase letters + 3 digits |
| **Course Name** | Required, 3-100 characters |
| **Credits** | Required, integer between 1 and 10 |

## Architecture & Design Patterns

### Model-View-Controller (MVC)

The application follows the MVC architectural pattern:

- **Models**: Define data structures and business logic
- **Views**: Render the user interface using Razor syntax
- **Controllers**: Handle HTTP requests and coordinate between models and views

### Object-Oriented Programming

The project demonstrates key OOP principles:

- **Inheritance**: `Student` and `Instructor` inherit from abstract `Person` class
- **Polymorphism**: `DisplayInfo()` method implemented differently in derived classes
- **Encapsulation**: Properties with appropriate access modifiers
- **Abstraction**: `ILogin` interface for login functionality

### Design Patterns Used

- **Repository Pattern**: Simulated with static lists (ready for database implementation)
- **Data Transfer Objects**: Models serve as DTOs between layers
- **Dependency Injection**: Built-in ASP.NET Core DI container

## Important Notes

### Data Persistence

⚠️ **Important**: This application uses **in-memory storage** with static lists. This means:

- All data is lost when the application stops
- Data resets to sample data on each restart
- Not suitable for production use without database integration

For production deployment, you should integrate a database using Entity Framework Core with SQL Server, PostgreSQL, MySQL, or another database system.

### Security Considerations

This is a demonstration/educational project. For production use, consider:

- Implementing authentication and authorization
- Adding CSRF protection (partially implemented)
- Implementing proper error handling and logging
- Using HTTPS in production
- Sanitizing user inputs
- Implementing rate limiting

## Future Enhancements

Potential improvements for this system:

### Database Integration
- Replace in-memory storage with Entity Framework Core
- Support for SQL Server, PostgreSQL, or MySQL
- Implement proper data persistence and migrations

### Authentication & Authorization
- User login system with role-based access
- Separate portals for students, instructors, and administrators
- Password hashing and secure authentication

### Additional Features
- Search and filter functionality
- Student grade management
- Course scheduling and calendar
- Attendance tracking
- Report generation (PDF/Excel)
- Email notifications
- File upload for student/instructor photos

### API Development
- RESTful API endpoints
- Support for mobile applications
- Integration with external systems

### Testing
- Unit tests for models and business logic
- Integration tests for controllers
- UI/E2E testing with Selenium or Playwright

## Troubleshooting

### Common Issues

**Issue**: Application won't start
- **Solution**: Ensure .NET 9.0 SDK is installed. Run `dotnet --version` to verify.

**Issue**: Port already in use
- **Solution**: Change the port in `Properties/launchSettings.json` or stop the application using that port.

**Issue**: Validation errors not showing
- **Solution**: Ensure JavaScript is enabled in your browser and validation scripts are loaded.

**Issue**: Build errors
- **Solution**: Run `dotnet restore` to restore NuGet packages, then `dotnet build`.

## Contributing

This is an educational project. Feel free to:
- Fork the repository
- Make improvements
- Add new features
- Fix bugs
- Enhance documentation

## License

This project is provided as-is for educational purposes. Feel free to use, modify, and distribute as needed.


---

**Version**: 1.0.0  
**Last Updated**: January 2025  
**Framework**: ASP.NET Core 9.0
