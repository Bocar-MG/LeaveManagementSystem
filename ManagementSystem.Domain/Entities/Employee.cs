using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Domain.Entities;

public class Employee
{
    public Guid Id { get; set; }
    public string FullName { get; set; }

    public string Department { get; set; }

    public DateTime JoiningDate { get; set; }
}
