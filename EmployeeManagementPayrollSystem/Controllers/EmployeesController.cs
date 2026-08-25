using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Data;
using EmployeeManagementPayrollSystemUI.Models;

namespace EmployeeManagementPayrollSystemUI.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeesController(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: /Employees/
        public IActionResult Index()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return View(employees);
        }

        // GET: /Employees/Details/5
        public IActionResult Details(int id)
        {
            var employee = _employeeRepository.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // GET: /Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Employees/CreateConfirmed
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateConfirmed(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", employee);
            }

            _employeeRepository.Create(employee);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Employees/Update/5
        public IActionResult Update(int id)
        {
            var employee = _employeeRepository.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: /Employees/UpdateConfirmed
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateConfirmed(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", employee);
            }

            _employeeRepository.UpdateEmployee(employee);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Employees/Delete/5 (Loads confirmation page)
        public IActionResult Delete(int id)
        {
            var employee = _employeeRepository.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: /Employees/DeleteConfirmed
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _employeeRepository.DeactivateEmployee(id);
            return RedirectToAction(nameof(Index));
        }
    }
}