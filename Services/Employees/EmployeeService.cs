using Microsoft.EntityFrameworkCore;
using tickets.Data;
using tickets.Models;

namespace tickets.Services.Employees;

public class EmployeeService : IEmployeeService
{
    private readonly ApplicationContext context;

    public EmployeeService(ApplicationContext context)
    {
        this.context = context;
    }

    public async Task<Employee> GetEmployeeAsync(Guid Id)
        => await context.Employees.FirstOrDefaultAsync(x => x.Id.Equals(Id));

    public async Task<ICollection<Employee>> GetEmployeesAsync()
        => await context.Employees.ToListAsync();

    public void AddEmployee(Employee employee)
        => context.Employees.Add(employee);
}
