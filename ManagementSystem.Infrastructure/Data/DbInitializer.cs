using ManagementSystem.Domain.Entities;
using ManagementSystem.Domain.Enums;
using ManagementSystem.Infrastructure.Common.persistence;


namespace ManagementSystem.Infrastructure.Data;

public static class DbInitializer
{
    public static void Initialize(LeaveMgmtSystemDbContext context)
    {
        context.Database.EnsureCreated();
        
     
        if (context.Employees.Any())
            return;

        var employees = new List<Employee>
        {
            new Employee(
                "Alice Dupont",
                "Humans Ressources",
                new DateTime(2020, 3, 15)
            ),
            new Employee(
                "Bob Martin",
                "Computer Science",
                new DateTime(2019, 7, 1)
            ),
            new Employee(
                "Chloé Bernard",
                "Accountability",
                new DateTime(2021, 1, 10)
            )
        };

        context.Employees.AddRange(employees);
        context.SaveChanges();

       
var leaveRequests = new List<LeaveRequest>
{
    new LeaveRequest(
        employees[0].Id,
        LeaveType.Annual,
        new DateTime(2024, 6, 1),
        new DateTime(2024, 6, 10),
        "Vacances annuelles"
    ),
    new LeaveRequest(
        employees[1].Id,
        LeaveType.Sick,
        new DateTime(2024, 3, 5),
        new DateTime(2024, 3, 8),
        "Grippe saisonnière"
    ),
    new LeaveRequest(
        employees[2].Id,
        LeaveType.Other,
        new DateTime(2024, 4, 20),
        new DateTime(2024, 4, 21),
        "Urgence familiale"
    )
};

        context.LeaveRequests.AddRange(leaveRequests);
        context.SaveChanges();
     
    }
}

