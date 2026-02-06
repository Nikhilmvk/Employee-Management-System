using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpleEmployeeApp.Data;
using SimpleEmployeeApp.Models;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;
    public IndexModel(AppDbContext context) => _context = context;

    [BindProperty]
    public string Name { get; set; } = string.Empty;
    [BindProperty]
    public string Email { get; set; } = string.Empty;
    [BindProperty]
    public string Department { get; set; } = string.Empty;

    public List<Employee> Employees { get; set; } = new();

    public async Task OnGetAsync()
    {
        Employees = await _context.Employees.ToListAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!string.IsNullOrEmpty(Name))
        {
            var emp = new Employee
            {
                Name = Name,
                Email = Email,
                Department = Department
            };
            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();
        }

        Employees = await _context.Employees.ToListAsync();
        return Page();
    }
}
