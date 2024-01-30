namespace tickets.Models;

public class Team
{
    public Team()
    {
        
    }

    public Guid Id { get; private set; } = Guid.NewGuid();

    public ICollection<Employee> Members { get; private set; } = new List<Employee>();

    public void AddMember(Employee employee) => Members.Add(employee);
}
