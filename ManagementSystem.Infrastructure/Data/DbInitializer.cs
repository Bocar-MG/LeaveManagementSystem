using ManagementSystem.Domain.Entities;
using ManagementSystem.Domain.Enums;
using ManagementSystem.Infrastructure.Common.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            new Employee
            {
                Id = Guid.NewGuid(),
                FullName = "Alice Dupont",
                Department = "Humans Ressources",
                JoiningDate = new DateTime(2020, 3, 15)
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                FullName = "Bob Martin",
                Department = "Computer Science",
                JoiningDate = new DateTime(2019, 7, 1)
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                FullName = "Chloé Bernard",
                Department = "Accountability",
                JoiningDate = new DateTime(2021, 1, 10)
            }
        };

        context.Employees.AddRange(employees);
        context.SaveChanges();

       
        var leaveRequests = new List<LeaveRequest>
        {
            new LeaveRequest
            {
                Id = Guid.NewGuid(),
                EmployeeId = employees[0].Id,
                LeaveType = LeaveType.Annual,
                StartDate = new DateTime(2024, 6, 1),
                EndDate = new DateTime(2024, 6, 10),
                Status = Status.Approved,
                Reason = "Vacances annuelles",
                CreatedAt = DateTime.UtcNow
            },
            new LeaveRequest
            {
                Id = Guid.NewGuid(),
                EmployeeId = employees[1].Id,
                LeaveType = LeaveType.Sick,
                StartDate = new DateTime(2024, 3, 5),
                EndDate = new DateTime(2024, 3, 8),
                Status = Status.Approved,
                Reason = "Grippe saisonnière",
                CreatedAt = DateTime.UtcNow
            },
            new LeaveRequest
            {
                Id = Guid.NewGuid(),
                EmployeeId = employees[2].Id,
                LeaveType = LeaveType.Other,
                StartDate = new DateTime(2024, 4, 20),
                EndDate = new DateTime(2024, 4, 21),
                Status = Status.Pending,
                Reason = "Urgence familiale",
                CreatedAt = DateTime.UtcNow
            }
        };

        context.LeaveRequests.AddRange(leaveRequests);
        context.SaveChanges();
    }
}

