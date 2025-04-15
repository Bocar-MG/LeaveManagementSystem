using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Domain.Entities;

public class LeaveRequest
{
    public Guid Id { get; set; }

    public Guid EmployeeId { get; set; }

    public string LeaveType { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Status { get; set; } 

    public string Reason { get; set; }

    public DateTime CreatedAt { get; set; }
}
