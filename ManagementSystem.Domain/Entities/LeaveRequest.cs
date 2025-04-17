using ManagementSystem.Domain.Enums;
using ManagementSystem.Domain.Exceptions;

namespace ManagementSystem.Domain.Entities;

public class LeaveRequest
{
    public Guid Id { get; private set; }

    public Guid EmployeeId { get; private set; }

    public LeaveType LeaveType { get; private set; }

    public DateTime StartDate { get; private set; }

    public DateTime EndDate { get; private set; }

    public Status Status { get; private set; }

    public string Reason { get; private set; } = string.Empty;

    public DateTime CreatedAt { get; private set; }

    public Employee? Employee { get; private set; }

    private LeaveRequest() { }


    public LeaveRequest(Guid employeeId, LeaveType leaveType, DateTime start, DateTime end, string reason)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;

        SetDates(start, end);
        SetReason(reason);

        EmployeeId = employeeId;
        SetLeaveType(leaveType);
        Status = Status.Pending; 
    }

    public void SetLeaveType(LeaveType leaveType)
    {
        if (leaveType == LeaveType.Sick && string.IsNullOrWhiteSpace(Reason))
            throw new DomainException("Sick leave requires a reason.");

        LeaveType = leaveType;
    }


    public void SetDates(DateTime start, DateTime end)
    {
        if (start > end)
            throw new DomainException("Start date must be before end date");

        if ((end - start).TotalDays > 30)
            throw new DomainException("Leave request cannot exceed 30 days");

        StartDate = start;
        EndDate = end;
    }

    public void SetReason(string reason)
    {
        if (string.IsNullOrWhiteSpace(reason))
            throw new ArgumentException("Reason is required");

        Reason = reason;
    }

    public void UpdateAllFields(Guid employeeId, LeaveType leaveType, DateTime startDate, DateTime endDate, string reason)
    {
        EmployeeId = employeeId;
        LeaveType = leaveType;
        SetDates(startDate, endDate);
        SetReason(reason);
    }

    public void UpdateReasonAndLeaveType(string reason,LeaveType leaveType)
    {
        SetReason(reason);
        LeaveType = leaveType;
    }

    public void Approve() => Status = Status.Approved;

    public void Reject() => Status = Status.Rejected;



}
