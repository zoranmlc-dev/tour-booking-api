namespace TourBooking.Domain.Entities;

public class Tour
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }
    public int DurationHours { get; set; }

    public decimal Price { get; set; }

    public int Capacity { get; set; }
    public int AvailableSlots { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
