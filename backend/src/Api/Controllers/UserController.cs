using Application.Services.Abstractions;
using Domain.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<GarageController> _logger;
    private readonly IUserService _userService;

    public UserController(ILogger<GarageController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpPost]
    [HttpPost]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateUserAsync([FromBody] UpsertUserRequest upsertUserRequest)
    {
        var user = await _userService.CreateUserAsync(upsertUserRequest);
        return Created("/user", user);
    }
    
    [HttpPut("{userId:guid}")]
    public async Task<IActionResult> CreateUserAsync([FromRoute] Guid userId, [FromBody] UpsertUserRequest upsertUserRequest)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public async Task<IActionResult> GetUsersPaginatedAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var user = await _userService.ListUsersPaginatedAsync(pageNumber, pageSize);
        
        if(user.Items.Any())
            return Ok(user.Items);

        return NotFound();
    }
}