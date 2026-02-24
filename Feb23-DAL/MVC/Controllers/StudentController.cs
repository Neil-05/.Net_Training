using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // LIST
        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        // GET CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST CREATE
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }
    }
}