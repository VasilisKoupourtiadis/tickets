using System.ComponentModel.DataAnnotations;

namespace tickets.Models;

public class Ticket
{
    public Ticket()
    {
        
    }

    public Ticket(string title, string description, Employee employee)
    {
        Title = title;
        Description = description;
        IsPending = true;
        IsActive = false;
        IsClosed = false;
        Employee = employee;
    }

    public Guid Id { get; private set; } = Guid.NewGuid();

    [MaxLength(100)]
    public string Title { get; private set; } = string.Empty;

    [MaxLength(250)]
    public string Description { get; private set; } = string.Empty;

    public bool IsActive { get; private set; }

    public bool IsClosed { get; private set; }

    public bool IsPending { get; private set; }

    public string Status
    {
        get
        {
            if (IsActive)
                return "Active";

            else if (IsClosed)
                return "Closed";

            return "Pending";
        }
    }

    public DateTime Created { get; private set; } = DateTime.Now;

    public Guid EmployeeId { get; private set; }

    public Employee Employee { get; private set; } = null!;

    public void SetActiveStatus()
    {
        IsActive = true;
        IsClosed = false;
        IsPending = false;
    }

    public void SetClosedStatus()
    {
        IsClosed = true;
        IsActive = false;
        IsPending = false;
    }
}
