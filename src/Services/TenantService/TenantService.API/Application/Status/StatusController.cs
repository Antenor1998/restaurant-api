using Microsoft.AspNetCore.Mvc;

namespace TenantService.API.Application.Status;

[ApiController]
[Route("api/[controller]")]
public class StatusController : ControllerBase {
    [HttpGet("status")]
    public IActionResult GetStatus()
    {
        return Ok(new { message = "TenantService is up and running!", timestamp = DateTime.UtcNow });
    }
}
