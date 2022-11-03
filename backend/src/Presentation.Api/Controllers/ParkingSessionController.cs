using Application.Services.Abstractions;
using Domain.Models.ParkingSession;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Api.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class ParkingSessionController : ControllerBase
{
    
    private readonly ILogger<GarageController> _logger;
    private readonly IParkingSessionService _parkingSessionService;

    public ParkingSessionController(ILogger<GarageController> logger, IParkingSessionService parkingSessionService)
    {
        _logger = logger;
        _parkingSessionService = parkingSessionService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ParkingSessionDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> StartParkingSessionAsync([FromBody] StartParkingSessionRequest startParkingSessionRequest)
    {
        try
        {
            var parkingSession = await _parkingSessionService.StartParkingSessionAsync(startParkingSessionRequest);
            return Created("/parkingSession", parkingSession);
        }
        catch (Exception exception)
        {
            return Problem($"An error occurred when starting a Parking Session: {exception.Message}");
        }
    }
    
    [HttpPost("{sessionId:guid}/Stop")]
    [ProducesResponseType(typeof(ParkingSessionDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> StopParkingSessionAsync([FromRoute] Guid sessionId, [FromForm] DateTime stopTime)
    {
        try
        {
            var parkingSession = await _parkingSessionService.StopParkingSession(sessionId, stopTime);
            return Ok(parkingSession);
        }
        catch (Exception exception)
        {
            return Problem($"An error occurred when stopping a Parking Session: {exception.Message}");
        }
    }
}