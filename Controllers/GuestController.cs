using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class GuestController : ControllerBase
{
    private readonly GuestService _guestService;

    public GuestController(GuestService guestService)
    {
        _guestService = guestService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var guests = await _guestService.GetGuests();
        return Ok(guests);
    }
}