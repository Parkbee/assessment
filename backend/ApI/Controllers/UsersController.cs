using ApI.Data;
using ApI.Middleware;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApI.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly ParkingDbContext _parkingDbContext;

    public UsersController(ParkingDbContext parkingDbContext)
    {
        _parkingDbContext = parkingDbContext;
    }

    [HttpGet]
    public async Task<List<User>> GetUsers(CancellationToken cancellationToken)
    {
        var partnerId = User.Claims.First(x => x.Type == CustomClaimNames.PartnerId).Value;
        return await _parkingDbContext.Users.Where(x => x.PartnerId == partnerId).ToListAsync(cancellationToken);
    }
}