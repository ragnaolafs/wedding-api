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
        var guestEntity = await _guestService.Register(guestDto);
        return Ok(new GuestDto(guestEntity));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFood(int id, string food)
    {
        var guestEntity = await _guestService.UpdateFood(id, food);
        if (guestEntity == null)
        {
            return BadRequest("Guest not found");
        }

        return Ok(new GuestDto(guestEntity));
    }
}