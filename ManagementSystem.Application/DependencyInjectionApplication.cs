

using ManagementSystem.Application.Services;
using ManagementSystem.Application.Validators.ILeavePolicyValidator;
using Microsoft.Extensions.DependencyInjection;

namespace ManagementSystem.Application;

public static class DependencyInjectionApplication
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ILeaveRequestService, LeaveRequestService>();
        services.AddScoped<ILeavePolicyValidator, LeavePolicyValidator>();
        return services;
    }
}
