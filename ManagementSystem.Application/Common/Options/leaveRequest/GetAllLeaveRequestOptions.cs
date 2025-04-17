using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Application.Common.Options.leaveRequest;

public class GetAllLeaveRequestOptions
{

    public Guid? EmployeeId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? LeaveType { get; set; } 
    public int? Status { get; set; } 

    public string? SortField { get; set; }

    public SortOrder? SortOrder { get; set; }
}

public enum SortOrder
{
    Unsorted,
    Ascending,
    Descending,
}