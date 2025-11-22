using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.Mediator.Results.RentalResults
{
    public class GetRentalQueryResult
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car? Car { get; set; }
        public int UserId { get; set; }
        public AppUser? User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PickUpLocationId { get; set; }
        public Location? PickUpLocation { get; set; }
        public int DropOffLocationId { get; set; }
        public Location? DropOffLocation { get; set; }
        public decimal DailyPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Status { get; set; }
    }
}
