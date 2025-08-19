using System.ComponentModel.DataAnnotations;
using Training_Management_System_ITI_Project.Data;
using Training_Management_System_ITI_Project.Models;

namespace Training_Management_System_ITI_Project.Attributes
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return ValidationResult.Success;

            var context = validationContext.GetService<ApplicationDbContext>();
            if (context == null)
                return ValidationResult.Success;

            var email = value.ToString()!;
            var user = validationContext.ObjectInstance as User;

            // Check if email exists (excluding current user if editing)
            var existingUser = context.Users
                .FirstOrDefault(u => u.Email.ToLower() == email.ToLower() && 
                                    (user == null || u.Id != user.Id));

            if (existingUser != null)
            {
                return new ValidationResult("A user with this email already exists.");
            }

            return ValidationResult.Success;
        }
    }
}
