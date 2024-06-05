namespace Data.Entities;

public class GuestEntity : IDateProperties
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string? LastName { get; set; }

    public bool? Going { get; set; }

    public string? Diet { get; set; }

    public int? SpouseId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}