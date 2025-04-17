using ManagementSystem.Application.Common.Interfaces;
using ManagementSystem.Infrastructure.Common.persistence;
using ManagementSystem.Infrastructure.leaveRequest.persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace ManagementSystem.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<LeaveMgmtSystemDbContext>(options => options.UseSqlite("Data source = LeaveMgmtSystem.db"));
        services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
        return services;
    }
}


