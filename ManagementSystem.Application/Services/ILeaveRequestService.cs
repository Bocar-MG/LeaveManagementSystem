

using ManagementSystem.Application.Common.Options.leaveRequest;
using ManagementSystem.Domain.Entities;
using ManagementSystem.Domain.Enums;

namespace ManagementSystem.Application.Services;

public interface ILeaveRequestService
{
    Task CreateLeaveRequestAsync(Guid employeeId, DateTime startDate, DateTime endDate, string reason);
    Task<List<LeaveRequest>> GetAllLeaveRequestsAsync(GetAllLeaveRequestOptions getAllLeaveRequestOptions);

    Task<LeaveRequest?> GetLeaveRequestByIdAsync(Guid id);
    Task<bool> UpdateLeaveRequestAsync(Guid id, string reason, int leaveType);
    Task<bool> DeleteLeaveRequestAsync(Guid id);
}
