# Training Management System

## Overview

A comprehensive ASP.NET Core MVC web application designed for managing training programs, including courses, sessions, users, and grades. This system implements modern software engineering practices including the Repository Pattern, comprehensive validation, and clean architecture principles.

## 🚀 Features

### Core Functionality

#### 🎓 Course Management
- **Create, Read, Update, Delete** courses
- **Instructor Assignment** - Assign qualified instructors to courses
- **Advanced Search** - Search courses by name or category
- **Unique Validation** - Ensures course names are unique across the system

**Validation Rules:**
- Name: Required, 3–50 characters, must be unique
- Category: Required field for organization
- Instructor: Optional assignment to qualified users

#### 📅 Session Management
- **Schedule Management** - Create and manage training sessions for courses
- **Date Validation** - Prevents scheduling in the past
- **Duration Control** - End date must be after start date
- **Course Association** - Link sessions to specific courses
- **Search Functionality** - Find sessions by course name

**Validation Rules:**
- StartDate: Required, cannot be in the past
- EndDate: Required, must be after StartDate
- CourseId: Required association with existing course

#### 👥 User Management
- **Multi-Role System** - Support for Admin, Instructor, and Trainee roles
- **User CRUD Operations** - Complete user lifecycle management
- **Email Validation** - Ensures unique, valid email addresses
- **Role-Based Features** - Different capabilities based on user role

**User Roles:**
- **Admin**: Full system access and management capabilities
- **Instructor**: Course and session management for assigned courses
- **Trainee**: Session participation and grade viewing

**Validation Rules:**
- Name: Required, 3–50 characters
- Email: Required, valid email format, must be unique
- Role: Required selection from defined roles

#### 📊 Grades Management
- **Performance Tracking** - Record grades for trainees in sessions
- **Grade Reports** - View individual trainee performance
- **Validation Controls** - Ensures grades are within acceptable range
- **Session Association** - Links grades to specific training sessions

**Validation Rules:**
- Value: Required, must be between 0 and 100
- SessionId: Required association with existing session
- TraineeId: Required association with trainee user

## 🏗️ Technical Architecture

### Design Patterns
- **Repository Pattern**: Abstracts data access logic for testability and maintainability
- **Dependency Injection**: Promotes loose coupling and easier testing
- **MVC Pattern**: Separates concerns between Model, View, and Controller layers

### Data Models

```csharp
// Core entities with their relationships
Course: Id, Name, Category, InstructorId
Session: Id, CourseId, StartDate, EndDate
User: Id, Name, Email, Role
Grade: Id, SessionId, TraineeId, Value
```

### Validation Strategy
- **Data Annotations**: Standard validation attributes for common rules
- **Custom Validation**: Business-specific validation attributes
- **Client-Side Validation**: Real-time feedback for better user experience
- **Server-Side Validation**: Comprehensive validation as security backstop

### Custom Validation Attributes
- `FutureDateAttribute`: Ensures dates are not in the past
- `DateGreaterThanAttribute`: Compares two date properties
- `UniqueCourseNameAttribute`: Prevents duplicate course names
- `UniqueEmailAttribute`: Ensures email uniqueness

## 🛠️ Technology Stack

- **Framework**: ASP.NET Core 8.0 MVC
- **Database**: SQL Server with Entity Framework Core
- **Frontend**: Razor Views with Bootstrap styling
- **Validation**: Data Annotations + Custom Attributes
- **Architecture**: Repository Pattern with Dependency Injection

## 📋 Prerequisites

- .NET 8.0 SDK or later
- SQL Server (LocalDB, Express, or Full version)
- Visual Studio 2022 or VS Code
- Git for version control

## 🚀 Getting Started

### 1. Clone the Repository
```bash
git clone https://github.com/Ahmedfahmy8308/Training-Management-System-ITI-Project.git
cd Training-Management-System-ITI-Project
```

### 2. Configure Database Connection
Update the connection string in `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TrainingManagementDB;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

### 3. Restore Dependencies
```bash
dotnet restore
```

### 4. Run the Application
```bash
dotnet run
```

The application will start and automatically create the database on first run.

### 5. Access the Application
Open your browser and navigate to `https://localhost:5001` or `http://localhost:5000`

## 📁 Project Structure

```
Training-Management-System-ITI-Project/
├── Controllers/           # MVC Controllers handling HTTP requests
├── Models/               # Entity models and business logic
├── Views/                # Razor view templates
├── ViewModels/           # Data transfer objects for views
├── Repositories/         # Data access layer implementation
├── Attributes/           # Custom validation attributes
├── Data/                 # Entity Framework DbContext
├── Migrations/           # Database schema migrations
├── wwwroot/             # Static files (CSS, JS, images)
└── Program.cs           # Application entry point and configuration
```

## 🎯 Usage Examples

### Creating a Course
1. Navigate to **Courses** → **Create New**
2. Enter course name (unique, 3-50 characters)
3. Select or enter course category
4. Optionally assign an instructor
5. Save the course

### Scheduling a Session
1. Navigate to **Sessions** → **Create New**
2. Select an existing course
3. Set start date (cannot be in the past)
4. Set end date (must be after start date)
5. Save the session

### Recording Grades
1. Navigate to **Grades** → **Create New**
2. Select a session
3. Choose a trainee
4. Enter grade value (0-100)
5. Save the grade

## 🔧 Configuration

### Database Settings
The application uses Entity Framework Core with SQL Server. The database is automatically created on first run with the schema defined by the models.

### Environment Configuration
- **Development**: Detailed error pages and developer tools
- **Production**: Secure error handling and performance optimizations

## 🧪 Testing

The application includes comprehensive validation testing through:
- Data annotation validation
- Custom validation attributes
- Controller action validation
- Client-side validation feedback

## 📈 Future Enhancements

- **Authentication & Authorization**: Implement user login/logout functionality
- **Reporting Dashboard**: Advanced analytics and reporting features
- **Email Notifications**: Automated session reminders and grade notifications
- **File Upload**: Support for course materials and assignments
- **API Development**: RESTful API for mobile applications
- **Advanced Search**: Filter by date ranges, instructor, and more criteria

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 📧 Contact

**Project Maintainer**: Ahmed Fahmy  
**Email**: [Contact through GitHub](https://github.com/Ahmedfahmy8308)  
**Project Link**: [https://github.com/Ahmedfahmy8308/Training-Management-System-ITI-Project](https://github.com/Ahmedfahmy8308/Training-Management-System-ITI-Project)

## 🙏 Acknowledgments

- ITI (Information Technology Institute) for project requirements and guidance
- ASP.NET Core team for the excellent framework
- Entity Framework team for the robust ORM solution
- Bootstrap team for the responsive UI framework

---

*Built with ❤️ using ASP.NET Core MVC*