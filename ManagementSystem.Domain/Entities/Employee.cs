using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Domain.Entities;

public class Employee
{
    public Guid Id { get; private set; }

    public  string FullName { get; private set; }

    public string Department { get; private set; }

    public DateTime JoiningDate { get; private set; }

    private Employee() { }

    public Employee(string fullName, string department, DateTime joiningDate)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("Full name is required");

        if (string.IsNullOrWhiteSpace(department))
            throw new ArgumentException("Department is required");

        if (joiningDate > DateTime.UtcNow)
            throw new ArgumentException("Joining date cannot be in the future");

        Id = Guid.NewGuid();
        FullName = fullName;
        Department = department;
        JoiningDate = joiningDate;
    }

    public void ChangeDepartment(string newDepartment)
    {
        if (string.IsNullOrWhiteSpace(newDepartment))
            throw new ArgumentException("Department cannot be empty");

        Department = newDepartment;
    }
}
