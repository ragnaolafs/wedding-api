using Data;
using Data.Entities;
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

    public async Task<GuestEntity> Register(GuestDto dto)
    {
        if (dto.FirstName.ToLower().Contains("wheelb") || dto.FirstName.ToLower().Contains("hjólb"))
        {
            dto.LastName = $"{dto.LastName} ({dto.FirstName})";
            dto.FirstName = "Hugi";
        }
        
        var entity = _context.Guest.Add(dto.ToEntity());
        await _context.SaveChangesAsync();
        return entity.Entity;
    }

    public async Task<GuestEntity> UpdateFood(int id, string food)
    {
        var guest = _context.Guest.FirstOrDefault(x => x.Id == id);
        if (guest == null)
        {
            return null;
        }

        guest.Diet = food;
        await _context.SaveChangesAsync();
        return guest;
    }
}