using System.ComponentModel.DataAnnotations;

namespace Training_Management_System_ITI_Project.Models
{
  /// <summary>
  /// Enumeration defining the different user roles in the training management system
  /// </summary>
  public enum UserRole
  {
    /// <summary>
    /// System administrator with full access to all features
    /// </summary>
    Admin,

    /// <summary>
    /// Course instructor who can manage assigned courses and sessions
    /// </summary>
    Instructor,

    /// <summary>
    /// Student/trainee who attends sessions and receives grades
    /// </summary>
    Trainee
  }

  /// <summary>
  /// Represents a user in the training management system.
  /// Users can be administrators, instructors, or trainees based on their role.
  /// No authentication system is implemented - role is stored as a simple field.
  /// </summary>
  public class User
  {
    /// <summary>
    /// Primary key - unique identifier for the user
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// User's full name - required field with length validation
    /// Must be between 3 and 50 characters for data consistency
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// User's email address - must be unique and in valid email format
    /// Used for identification and communication purposes
    /// </summary>
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// User's role in the system (Admin, Instructor, or Trainee)
    /// Determines what features and data the user can access
    /// </summary>
    [Required(ErrorMessage = "Role is required")]
    public UserRole Role { get; set; }

    // Navigation properties for Entity Framework relationships

    /// <summary>
    /// Collection of courses where this user serves as an instructor
    /// Only relevant for users with Instructor role
    /// </summary>
    public virtual ICollection<Course> CoursesAsInstructor { get; set; } = new List<Course>();

    /// <summary>
    /// Collection of grades received by this user when they are a trainee
    /// Only relevant for users with Trainee role
    /// </summary>
    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
  }
}
