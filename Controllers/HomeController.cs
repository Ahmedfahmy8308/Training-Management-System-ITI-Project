using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Training_Management_System_ITI_Project.Models;
using Training_Management_System_ITI_Project.Repositories;

namespace Training_Management_System_ITI_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICourseRepository _courseRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IGradeRepository _gradeRepository;

        public HomeController(ILogger<HomeController> logger, 
            ICourseRepository courseRepository,
            ISessionRepository sessionRepository,
            IUserRepository userRepository,
            IGradeRepository gradeRepository)
        {
            _logger = logger;
            _courseRepository = courseRepository;
            _sessionRepository = sessionRepository;
            _userRepository = userRepository;
            _gradeRepository = gradeRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TotalCourses = (await _courseRepository.GetAllAsync()).Count();
            ViewBag.TotalSessions = (await _sessionRepository.GetAllAsync()).Count();
            ViewBag.TotalUsers = (await _userRepository.GetAllAsync()).Count();
            ViewBag.TotalGrades = (await _gradeRepository.GetAllAsync()).Count();
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
