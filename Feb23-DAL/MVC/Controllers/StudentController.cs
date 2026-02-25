using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Models;
using Microsoft.Extensions.Logging;

namespace MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<StudentController> _logger;


        public StudentController(ApplicationDbContext context, ILogger<StudentController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Fetchingfrom the Database....");
            var students = _context.Students.ToList();
            _logger.LogInformation("Fetched students from the database "+ students.Count);
            return View(students);
        }

        // GET CREATE
        public IActionResult Create()
        {
            _logger.LogInformation("Create Page Opened....");
            return View();
        }

        // POST CREATE
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation($"Adding a new student to the Database {student.FullName}");
                _context.Students.Add(student);
                _context.SaveChanges();
                _logger.LogInformation($"Student Added Successfully....");
                return RedirectToAction("Index");
            }
            _logger.LogInformation("Invalid Model Submitted...");
            return View(student);
        }
    }
}