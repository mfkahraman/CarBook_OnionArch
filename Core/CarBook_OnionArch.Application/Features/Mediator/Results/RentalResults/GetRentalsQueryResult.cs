using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.Mediator.Results.RentalResults
{
    public class GetRentalsQueryResult
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car? Car { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PickUpLocationId { get; set; }
        public Location? PickUpLocation { get; set; }
        public int DropOffLocationId { get; set; }
        public Location? DropOffLocation { get; set; }
        public decimal DailyPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public RentalStatus Status { get; set; }

        public enum RentalStatus
        {
            Pending = 0,
            Active = 1,
            Completed = 2,
            Cancelled = 3
        }
    }
}
