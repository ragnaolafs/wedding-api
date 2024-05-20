namespace Data.Entities;

public class GuestEntity
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string? LastName { get; set; }

    public bool? Going { get; set; }

    public string? Diet { get; set; }
}