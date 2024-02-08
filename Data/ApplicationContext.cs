using Microsoft.EntityFrameworkCore;
using tickets.Models;

namespace tickets.Data;

public class ApplicationContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    public DbSet<Team> Teams { get; set; }

    public DbSet<Ticket> Tickets { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var teams = new List<Team>()
        { 
            new("Team #1"), 
            new("Team #2"), 
            new("Team #3"),
            new("Team #4")
        };

        modelBuilder.Entity<Team>().HasData(teams);
    }
}
