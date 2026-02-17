using TourBooking.Domain.Enums;

namespace TourBooking.Domain.Entities;

public class Booking
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid TourId { get; set; }
    public Tour? Tour { get; set; }

    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;

    public int SeatsBooked { get; set; }

    public BookingStatus Status { get; set; } = BookingStatus.Confirmed;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
