using ManagementSystem.Application;
using ManagementSystem.Infrastructure;
using ManagementSystem.Infrastructure.Common.persistence;
using ManagementSystem.Infrastructure.Data;
using ManagementSystem.WebApi.ExceptionHandlerMiddleware;
using Scalar.AspNetCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddApplication()
    .AddInfrastructure();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapOpenApi();
app.MapScalarApiReference();
/*if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();

}
*/

    using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<LeaveMgmtSystemDbContext>();
    DbInitializer.Initialize(dbContext);
}
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();
app.UseHttpsRedirection();



app.Run();


