using DTOs;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]
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

    [HttpPost]
    public async Task<IActionResult> Register(GuestDto guestDto)
    {
        await _guestService.Register(guestDto);
        return Ok();
    }
}