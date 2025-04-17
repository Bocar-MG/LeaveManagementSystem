using ManagementSystem.Application.Common.Options.leaveRequest;
using ManagementSystem.Domain.Entities;


namespace ManagementSystem.Application.Common.Interfaces;

public interface ILeaveRequestRepository
{

    Task<List<LeaveRequest>> GetAllAsync(GetAllLeaveRequestOptions getAllLeaveRequestOptions);
    Task AddLeaveRequestAsync(LeaveRequest leaveRequest);

    Task<LeaveRequest?> GetLeaveRequestByIdAsync(Guid id);

    Task UpdateLeaveRequestAsync(LeaveRequest leaveRequest);

    Task DeleteLeaveRequestAsync(LeaveRequest leaveRequest);
}
