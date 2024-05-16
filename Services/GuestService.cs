using Data;
using DTOs;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class GuestService
{
    private readonly WeddingContext _context;

    public GuestService(WeddingContext context)
    {
        _context = context;
    }

    public async Task<List<GuestDto>> GetGuests()
    {
        var guestEntities = await _context.Guest.ToListAsync();
        return guestEntities.Select(x => new GuestDto(x)).ToList();
    }

    public async Task Register(GuestDto dto)
    {
        var entity = dto.ToEntity();
        _context.Guest.Add(entity);
        await _context.SaveChangesAsync();
    }
}