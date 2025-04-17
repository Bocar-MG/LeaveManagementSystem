using ManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Application.Validators.ILeavePolicyValidator;

public interface ILeavePolicyValidator
{
    Task ValidateLeaveRequestAsync(LeaveRequest request);
}
