

namespace ManagementSystem.Contracts.leaveRequest.Request;

public class CreateLeaveRequest
{
    public Guid EmployeeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Reason { get; set; } = string.Empty;
    public int LeaveType { get; set; }





}
