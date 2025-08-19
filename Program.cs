using Microsoft.EntityFrameworkCore;
using Training_Management_System_ITI_Project.Data;
using Training_Management_System_ITI_Project.Repositories;

namespace Training_Management_System_ITI_Project
{
  /// <summary>
  /// Main entry point for the Training Management System application.
  /// This ASP.NET Core MVC application manages courses, sessions, users, and grades
  /// using the Repository Pattern for data access.
  /// </summary>
  public class Program
  {
    /// <summary>
    /// Application entry point - configures services and middleware pipeline
    /// </summary>
    /// <param name="args">Command line arguments</param>
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      // Configure MVC services for controllers and views
      builder.Services.AddControllersWithViews();

      // Configure Entity Framework with SQL Server database
      // Connection string is retrieved from appsettings.json
      builder.Services.AddDbContext<ApplicationDbContext>(options =>
          options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

      // Register Repository Pattern implementations for dependency injection
      // Each repository handles data access for a specific entity type
      builder.Services.AddScoped<ICourseRepository, CourseRepository>();
      builder.Services.AddScoped<ISessionRepository, SessionRepository>();
      builder.Services.AddScoped<IUserRepository, UserRepository>();
      builder.Services.AddScoped<IGradeRepository, GradeRepository>();

      var app = builder.Build();

      // Initialize database - ensure it's created on first run
      // This replaces the need for manual database creation during development
      using (var scope = app.Services.CreateScope())
      {
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.EnsureCreated();
      }

      // Configure the HTTP request pipeline for different environments
      if (!app.Environment.IsDevelopment())
      {
        // Production error handling - redirect to friendly error page
        app.UseExceptionHandler("/Home/Error");
        // HTTP Strict Transport Security (HSTS) for enhanced security
        app.UseHsts();
      }

      // Enforce HTTPS redirection for secure communication
      app.UseHttpsRedirection();

      // Enable serving static files (CSS, JS, images) from wwwroot
      app.UseStaticFiles();

      // Enable routing to match URLs to controllers/actions
      app.UseRouting();

      // Enable authorization middleware (even though we're not using authentication yet)
      app.UseAuthorization();

      app.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}");

      app.Run();
    }
  }
}
