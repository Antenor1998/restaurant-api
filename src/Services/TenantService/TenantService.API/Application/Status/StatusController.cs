using Microsoft.AspNetCore.Mvc;
using SharedKernel.lib.Messaging;

namespace TenantService.API.Application.Status;

[ApiController]
[Route("api/[controller]")]
public class StatusController : ControllerBase {

	private readonly IEventBus _eventBus;
	public StatusController(IEventBus eventBus){
		_eventBus = eventBus;
	}

	[HttpGet("status")]
	public IActionResult GetStatus() {
		return Ok(new { message = "TenantService is up and running!", timestamp = DateTime.UtcNow });
	}



	[HttpPost("generate")]
    public async Task<IActionResult> GenerateIncident(string employeeId) {
        if (!string.IsNullOrEmpty(employeeId)) {
            // var eventToPublish = new AttendanceIncidentGeneratedIntegrationEvent(employeeId, "ClientAlias", "RecordId");
            // await _eventBus.PublishAsync(eventToPublish);
        }

        return Ok("Event published");
    }


}
