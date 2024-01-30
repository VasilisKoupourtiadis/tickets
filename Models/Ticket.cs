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
        Employee = employee;
    }

    public Guid Id { get; private set; } = Guid.NewGuid();

    [MaxLength(100)]
    public string Title { get; private set; } = string.Empty;

    [MaxLength(250)]
    public string Description { get; private set; } = string.Empty;

    public bool IsActive { get { return IsActive; } private set { SetActiveStatus(); } }

    public bool IsClosed { get { return IsClosed; } private set { SetClosedStatus(); } }

    public bool IsPending { get; private set; }

    public string Status
    {
        get 
        {
            if (IsActive)
                return nameof(IsActive);

            else if (IsClosed)
                return nameof(IsClosed);

            return nameof(IsPending);
        }
    }

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
