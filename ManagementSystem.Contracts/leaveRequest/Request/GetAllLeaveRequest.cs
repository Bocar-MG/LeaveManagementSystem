using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Contracts.leaveRequest.Request;

public class GetAllLeaveRequest
{
   public Guid? EmployeeId { get; set; }
   public DateTime? StartDate { get; set; }
  
   public DateTime? EndDate { get; set; }
   public int? LeaveType { get; set; } 

   public int? Status { get; set; } 

   public string? SortBy { get; set; }
}
