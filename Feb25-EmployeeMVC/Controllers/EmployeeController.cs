using Microsoft.AspNetCore.Mvc;
using Feb25_EmployeeMVC.Data;
using Feb25_EmployeeMVC.Models;

namespace Feb25_EmployeeMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();

            return View(employees);
        }
        public IActionResult Hello()
        {
            return Content("Hello Works");
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Average()
        {
            var avg = _context.Employees.Average(e => e.Amount);
            return Content($"Average Amount: {avg}");
        }


        public IActionResult Edit(int id)
        {
            var emp = _context.Employees.Find(id);
            if (emp == null) return NotFound();
            return View(emp);
        }

        public IActionResult Delete(int id)
        {
            var emp = _context.Employees.Find(id);
            if (emp == null) return NotFound();
            return View(emp);
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            if (!ModelState.IsValid)
            {
                return View(emp);
            }

            var existing = _context.Employees.Find(emp.EmployeeId);

            if (existing == null)
                return NotFound();

            existing.FullName = emp.FullName;
            existing.Dept = emp.Dept;
            existing.Amount = emp.Amount;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var emp = _context.Employees.Find(id);
            _context.Employees.Remove(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}