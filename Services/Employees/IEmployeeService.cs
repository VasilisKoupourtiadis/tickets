using tickets.Models;

namespace tickets.Services.Employees;

public interface IEmployeeService
{
    void AddEmployee(Employee employee);

    Task<Employee> GetEmployeeAsync(Guid Id);

    Task<ICollection<Employee>> GetEmployeesAsync();
}