using ManagementSystem.Application.Common.Interfaces;
using ManagementSystem.Application.Common.Options.leaveRequest;
using ManagementSystem.Domain.Entities;
using ManagementSystem.Domain.Enums;
using ManagementSystem.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Application.Validators.ILeavePolicyValidator;

public class LeavePolicyValidator : ILeavePolicyValidator
{
    private readonly ILeaveRequestRepository _repo;
    public LeavePolicyValidator(ILeaveRequestRepository repo)
    {
        _repo = repo;
    }
  
  

    public async Task ValidateLeaveRequestAsync(LeaveRequest request)
    {
        var existing = await _repo.GetAllAsync(new GetAllLeaveRequestOptions
        {
            EmployeeId = request.EmployeeId,
            StartDate = request.StartDate,
            EndDate = request.EndDate
        });

        if (existing.Any(x =>
            x.Id != request.Id &&
            x.StartDate < request.EndDate &&
            x.EndDate > request.StartDate))
        {
            throw new DomainException("\"There is already a leave request that overlaps these dates.");
        }

        
        if (request.LeaveType == LeaveType.Annual)
        {
            var totalDays = existing
                .Where(x => x.LeaveType == LeaveType.Annual && x.StartDate.Year == request.StartDate.Year)
                .Sum(x => (x.EndDate - x.StartDate).TotalDays + 1);

            totalDays += (request.EndDate - request.StartDate).TotalDays + 1;

            if (totalDays > 20)
                throw new DomainException("The total number of annual leave days exceeds the allowed limit of 20 days.");

        }
    }
}

