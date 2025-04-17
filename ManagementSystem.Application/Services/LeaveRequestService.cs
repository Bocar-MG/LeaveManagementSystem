using ManagementSystem.Application.Common.Interfaces;
using ManagementSystem.Application.Common.Options.leaveRequest;
using ManagementSystem.Application.Validators.ILeavePolicyValidator;
using ManagementSystem.Domain.Entities;
using ManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Application.Services;

public class LeaveRequestService : ILeaveRequestService
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeavePolicyValidator _policy;

    public LeaveRequestService(ILeaveRequestRepository leaveRequestRepository,ILeavePolicyValidator leavePolicy)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _policy = leavePolicy;
    }
    public async Task CreateLeaveRequestAsync(Guid employeeId, DateTime startDate, DateTime endDate, string reason)
    {
        var leaveRequest = new LeaveRequest(employeeId, LeaveType.Annual, startDate, endDate, reason);
        await _policy.ValidateLeaveRequestAsync(leaveRequest);
        await _leaveRequestRepository.AddLeaveRequestAsync(leaveRequest);

    }

    public async Task<bool> DeleteLeaveRequestAsync(Guid id)
    {
        var leaveRequest = await _leaveRequestRepository.GetLeaveRequestByIdAsync(id);
        if (leaveRequest == null || leaveRequest.Status == Status.Approved)
        {
            return false;
        }

        await _leaveRequestRepository.DeleteLeaveRequestAsync(leaveRequest);
        return true;


    }

    public async Task<List<LeaveRequest>> GetAllLeaveRequestsAsync(GetAllLeaveRequestOptions getAllLeaveRequestOptions)
    {
        var leaveRequests = await _leaveRequestRepository.GetAllAsync(getAllLeaveRequestOptions);
       
        return leaveRequests;
    }

    public async Task<LeaveRequest?> GetLeaveRequestByIdAsync(Guid id)
    {
       var leaverequest =  await _leaveRequestRepository.GetLeaveRequestByIdAsync(id);
      
        return leaverequest;
    }

    public async Task<bool> UpdateLeaveRequestAsync(Guid id,string reason,int leaveType)
    {
      
        var leaveRequest = await _leaveRequestRepository.GetLeaveRequestByIdAsync(id);
        if (leaveRequest == null || leaveRequest.Status == Status.Approved)
        {
            return false;
        }
        leaveRequest.UpdateReasonAndLeaveType(reason,(LeaveType)leaveType);
        await _policy.ValidateLeaveRequestAsync(leaveRequest);
        await _leaveRequestRepository.UpdateLeaveRequestAsync(leaveRequest);

        return true;



    }
}
