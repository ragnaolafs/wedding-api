using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class GuestService
{
    private readonly WeddingContext _context;

    public GuestService(WeddingContext context)
    {
        _context = context;
    }

    public async Task<List<GuestEntity>> GetGuests()
    {
        return await _context.Guest.ToListAsync();
    }
}