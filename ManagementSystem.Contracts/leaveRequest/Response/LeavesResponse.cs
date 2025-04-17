using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Contracts.leaveRequest.Response;

public class LeavesResponse
{
    public  List<LeaveRequestResponse> Items { get; init; } = new List<LeaveRequestResponse>();
}
