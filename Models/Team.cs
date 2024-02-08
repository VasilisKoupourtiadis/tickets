namespace tickets.Models;

public class Team
{
    public Team()
    {
        
    }

    public Team(string name)
    {
        Name = name;
    }

    public Guid Id { get; private set; } = Guid.NewGuid();

    public string Name { get; private set; } = string.Empty;

    public ICollection<Employee> Members { get; private set; } = new List<Employee>();

    public void AddMember(Employee employee) => Members.Add(employee);
}
