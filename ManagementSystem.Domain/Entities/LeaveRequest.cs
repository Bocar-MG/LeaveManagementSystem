﻿using ManagementSystem.Domain.Enums;
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

    public LeaveType LeaveType { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public Status Status { get; set; } 

    public string Reason { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}
