using ManagementSystem.Application.Common.Interfaces;
using ManagementSystem.Application.Common.Options.leaveRequest;
using ManagementSystem.Domain.Entities;
using ManagementSystem.Domain.Enums;
using ManagementSystem.Infrastructure.Common.persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace ManagementSystem.Infrastructure.leaveRequest.persistence;

public class LeaveRequestRepository : ILeaveRequestRepository
{
    private LeaveMgmtSystemDbContext _context;
    public LeaveRequestRepository(LeaveMgmtSystemDbContext context)
    {
        _context = context;
    }

    public async Task AddLeaveRequestAsync(LeaveRequest leaveRequest)
    {
        _context.LeaveRequests.Add(leaveRequest);
         await _context.SaveChangesAsync();

    }

    public async Task DeleteLeaveRequestAsync(LeaveRequest leaveRequest)
    {
   
         _context.LeaveRequests.Remove(leaveRequest);
            
          await _context.SaveChangesAsync() ;

    }

    public async Task<List<LeaveRequest>> GetAllAsync(GetAllLeaveRequestOptions getAllLeaveRequestOptions)
    {   
        

        var query = _context.LeaveRequests.AsQueryable();

        if (getAllLeaveRequestOptions.EmployeeId.HasValue)
            query = query.Where(x => x.EmployeeId == getAllLeaveRequestOptions.EmployeeId.Value);

        if (getAllLeaveRequestOptions.Status.HasValue)
            query = query.Where(x => x.Status == (Status)getAllLeaveRequestOptions.Status.Value);

        if(getAllLeaveRequestOptions.StartDate.HasValue)
            query = query.Where(x => x.StartDate >= getAllLeaveRequestOptions.StartDate.Value);

        if (getAllLeaveRequestOptions.EndDate.HasValue)
            query = query.Where(x => x.EndDate <= getAllLeaveRequestOptions.EndDate.Value);

        if (getAllLeaveRequestOptions.LeaveType.HasValue)
            query = query.Where(x => x.LeaveType == (LeaveType)getAllLeaveRequestOptions.LeaveType.Value);

        if (!string.IsNullOrWhiteSpace(getAllLeaveRequestOptions.SortField))
        {
            string orderExpression = $"{getAllLeaveRequestOptions.SortField} {(getAllLeaveRequestOptions.SortOrder == SortOrder.Descending ? "descending" : "ascending")}";
            query = query.OrderBy(orderExpression);
        }

        var leaveRequests = await query.ToListAsync();

        return leaveRequests;
    }

    public async Task<LeaveRequest?> GetLeaveRequestByIdAsync(Guid id)
    {
        var leaveRequest = await _context.LeaveRequests.FindAsync(id);     
        return leaveRequest;

    }

    public async Task UpdateLeaveRequestAsync(LeaveRequest leaveRequest)
    {
       
            _context.Update(leaveRequest);
            await _context.SaveChangesAsync();
        
       
    }
}
