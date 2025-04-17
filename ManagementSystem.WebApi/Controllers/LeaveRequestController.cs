using ManagementSystem.Application.Services;
using ManagementSystem.Contracts.leaveRequest.Request;
using ManagementSystem.WebApi.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.WebApi.Controllers;

[ApiController]
public class LeaveRequestController : ControllerBase
{
    private readonly ILeaveRequestService _leaveRequestService;

    public LeaveRequestController(ILeaveRequestService leaveRequestService)
    {
        _leaveRequestService = leaveRequestService;
    }

    [HttpGet(ApiEndpoints.ApiEndpoints.LeaveRequests.GetAll)]
    public async Task<IActionResult> GetAll([FromQuery] GetAllLeaveRequest getAllLeaveRequest)
    {

        var options = getAllLeaveRequest.MapToGetAllLeaveRequestOptions();
        var leaveRequests = await _leaveRequestService.GetAllLeaveRequestsAsync(options);
        var leaveResponse = leaveRequests.MapToLeavesResponse();

        if (leaveResponse == null)
            return NotFound("No leave requests found");
        return Ok(leaveResponse);

    }

    [HttpPost(ApiEndpoints.ApiEndpoints.LeaveRequests.Create)]
    public async Task<IActionResult> Create([FromBody] CreateLeaveRequest leaveRequest)
    {
        if (leaveRequest == null)
            return BadRequest("Leave request cannot be null");
        var leaveRequestRespnse = leaveRequest.MapToLeaveRequest();
        await _leaveRequestService.CreateLeaveRequestAsync(leaveRequest.EmployeeId,leaveRequest.StartDate,leaveRequest.EndDate,leaveRequest.Reason);
        return CreatedAtAction(nameof(GetAll), new { id = leaveRequestRespnse.Id }, leaveRequestRespnse);



    }

    [HttpGet(ApiEndpoints.ApiEndpoints.LeaveRequests.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var leaveRequest = await _leaveRequestService.GetLeaveRequestByIdAsync(id);
        if (leaveRequest == null)
            return NotFound("Leave request not found");
        var leaveResponse = leaveRequest.MapToLeaveRequestResponse();
        return Ok(leaveResponse);
    }
    [HttpPut(ApiEndpoints.ApiEndpoints.LeaveRequests.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] CreateLeaveRequest leaveRequest)
    {
        if (leaveRequest == null)
            return BadRequest("Leave request cannot be null");
        var leaveRequestRespnse = leaveRequest.MapToLeaveRequest();
       var result =  await _leaveRequestService.UpdateLeaveRequestAsync(id, leaveRequest.Reason, leaveRequest.LeaveType);
        if(result)
        {
            return NoContent();
        }
        
        
        return NotFound();
    }

    [HttpDelete(ApiEndpoints.ApiEndpoints.LeaveRequests.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {

        var result =  await _leaveRequestService.DeleteLeaveRequestAsync(id);
        if(result)
        {
            return NoContent();
        }
        return NotFound("Leave request not found");



    }
}
