using Data.Entities;

namespace DTOs;

public class GuestDto
{
    public int Id { get; private set; }

    public string FirstName { get; set; }
    
    public string LastName { get; set; }

    public bool? Going { get; set; }

    public string? Diet { get; set; } = "Normal";

    public int? SpouseId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public GuestDto() { }

    public GuestDto(GuestEntity guestEntity)
    {
        Id = guestEntity.Id;
        FirstName = guestEntity.FirstName;
        LastName = guestEntity.LastName;
        Going = guestEntity.Going;
        Diet = guestEntity.Diet;
        SpouseId = guestEntity.SpouseId;
        CreatedAt = guestEntity.CreatedAt;
        UpdatedAt = guestEntity.UpdatedAt;
    }

    public GuestEntity ToEntity()
    {
        return new GuestEntity
        {
            FirstName = this.FirstName,
            LastName = this.LastName,
            Going = this.Going,
            Diet = this.Diet,
            SpouseId = this.SpouseId,
        };
    }
}