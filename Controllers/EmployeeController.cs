using Microsoft.AspNetCore.Mvc;
using DotNetSqlJenkins.Data;
using DotNetSqlJenkins.Models;

namespace DotNetSqlJenkins.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Employees.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var emp = _context.Employees.Find(id);
            if (emp == null)
                return NotFound();

            return Ok(emp);
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee employee)
        {
            var emp = _context.Employees.Find(id);
            if (emp == null)
                return NotFound();

            emp.Name = employee.Name;
            emp.Email = employee.Email;
            emp.Department = employee.Department;

            _context.SaveChanges();
            return Ok(emp);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp = _context.Employees.Find(id);
            if (emp == null)
                return NotFound();

            _context.Employees.Remove(emp);
            _context.SaveChanges();
            return Ok();
        }
    }
}
