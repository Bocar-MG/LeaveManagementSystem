using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Contracts.leaveRequest.Request;

public class PageRequest
{
    public required int Page { get; init; } = 1;
    public required int PageSize { get; init; } = 10;
}
