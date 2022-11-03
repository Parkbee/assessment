using Application.Services.Abstractions;
using Domain.Models.Garage;
using Domain.Models.Garage.Door;
using Domain.Models.Garage.Spot;
using Domain.Models.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class GarageController : ControllerBase
{
    private readonly ILogger<GarageController> _logger;
    private readonly IGarageService _garageService;

    public GarageController(ILogger<GarageController> logger, IGarageService garageService)
    {
        _logger = logger;
        _garageService = garageService;
    }

    // Garage
    [HttpPost]
    [ProducesResponseType(typeof(GarageDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateGarageAsync([FromBody] CreateGarageRequest createGarageRequest)
    {
        var garage = await _garageService.CreateGarageAsync(createGarageRequest);
        return Created("", garage);
    }

    [HttpPatch("{garageId:guid}")]
    [ProducesResponseType(typeof(GarageDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateGarageDetailsAsync([FromRoute] Guid garageId, [FromBody] UpdateGarageDetailsRequest updateGarageDetailsRequest)
    {
        try
        {
            var garage = await _garageService.UpdateGarageDetailsAsync(garageId, updateGarageDetailsRequest);
            return Ok(garage);
        }
        catch (Exception)
        {
            return NotFound();
        }
    }

    [HttpDelete("{garageId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteGarageAsync([FromRoute] Guid garageId)
    {
        await _garageService.DeleteGarageAsync(garageId);
        return Ok();
    }

    [HttpGet]
    [ProducesResponseType(typeof(IPagedResponse<GarageDto>),StatusCodes.Status200OK)]
    public async Task<IActionResult> GetGaragePaginatedAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var garages = await _garageService.ListGaragesPaginatedAsync(pageNumber, pageSize);
        if(garages.Items.Any())
            return Ok(garages.Items);

        return NotFound();
    }

    // Garage Doors
    [HttpPost("{garageId:guid}/door")]
    [ProducesResponseType(typeof(GarageDoorDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> AddGarageDoorAsync([FromRoute] Guid garageId, [FromBody] CreateGarageDoorRequest createGarageDoorRequest)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{garageId:guid}/door/{doorId:guid}")]
    [ProducesResponseType(typeof(GarageDoorDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateGarageDoorAsync([FromRoute] Guid garageId, [FromRoute] Guid doorId, [FromBody] UpdateGarageDoorRequest updateGarageDoorRequest)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{garageId:guid}/door/{doorId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteGarageDoor([FromRoute] Guid garageId, [FromRoute] Guid doorId)
    {
        throw new NotImplementedException();
    }
    
    // Garage Spots 
    [HttpPost("{garageId:guid}/spot")]
    [ProducesResponseType(typeof(GarageSpotDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> AddGarageSpotAsync([FromRoute] Guid garageId, [FromBody] UpsertGarageSpotRequest upsertGarageSpotRequest)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{garageId:guid}/spot/{spotId:guid}")]
    [ProducesResponseType(typeof(GarageSpotDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateGarageSpotAsync([FromRoute] Guid garageId, [FromRoute] Guid spotId,  [FromBody] UpsertGarageSpotRequest upsertGarageSpotRequest)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{garageId:guid}/spot/{spotId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteGarageSpot([FromRoute] Guid garageId, [FromRoute] Guid spotId)
    {
        throw new NotImplementedException();
    }
}