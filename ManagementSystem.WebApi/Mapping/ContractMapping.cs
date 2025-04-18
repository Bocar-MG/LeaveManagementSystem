using ManagementSystem.Application.Common.Options.leaveRequest;
using ManagementSystem.Contracts.leaveRequest.Request;
using ManagementSystem.Contracts.leaveRequest.Response;
using ManagementSystem.Domain.Entities;
using ManagementSystem.Domain.Enums;

namespace ManagementSystem.WebApi.Mapping;

// I used Mapping Extensions to map between the domain entities and the contract objects.
// i didn't use AutoMapper because i wanted to have more control over the mapping process and to avoid the overhead of using a third-party library.
// beacuse actually  many libraries are becoming commercial so it's a good practice to our own way
public static class ContractMapping
{
    public static LeaveRequest MapToLeaveRequest(this CreateLeaveRequest request)
    {
         return new LeaveRequest(
            request.EmployeeId,
            (LeaveType)request.LeaveType,
            request.StartDate,
            request.EndDate,
            request.Reason);

    }


    public static LeaveRequestResponse MapToLeaveRequestResponse(this LeaveRequest leaveRequest)
    {
        return new LeaveRequestResponse
        {
            Id = leaveRequest.Id,
            EmployeeId = leaveRequest.EmployeeId,
            StartDate = leaveRequest.StartDate,
            EndDate = leaveRequest.EndDate,
            Reason = leaveRequest.Reason
        };
    }

    public static LeavesResponse MapToLeavesResponse(this List<LeaveRequest> leavesRequests)
    {
        return new LeavesResponse
        {
            Items = leavesRequests.Select(x => new LeaveRequestResponse
            {
                Id = x.Id,
                EmployeeId = x.EmployeeId,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Reason = x.Reason
            }).ToList()
        };
    }

    
    public static GetAllLeaveRequestOptions MapToGetAllLeaveRequestOptions(this GetAllLeaveRequest getAllLeaveRequest)
    {
        return new GetAllLeaveRequestOptions
        {
            EmployeeId = getAllLeaveRequest.EmployeeId,
            StartDate = getAllLeaveRequest.StartDate,
            EndDate = getAllLeaveRequest.EndDate,
            LeaveType = getAllLeaveRequest.LeaveType,
            Status = getAllLeaveRequest.Status,
            SortField = getAllLeaveRequest.SortBy?.Trim('+','-'),
            SortOrder = getAllLeaveRequest.SortBy is null ? SortOrder.Unsorted:
               getAllLeaveRequest.SortBy.StartsWith('-') ? SortOrder.Descending : SortOrder.Ascending,
            Page = getAllLeaveRequest.Page,
            PageSize = getAllLeaveRequest.PageSize,

            SearchTerm = getAllLeaveRequest.SearchTerm,

        };
    }
}
