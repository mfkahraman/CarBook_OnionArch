namespace CarBook_OnionArch.Dto.RentalDtos
{
    public class ReservationDetailsDto
    {
        public string? CarName { get; set; }
        public int CarId { get; set; }
        public int? UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? PickUpLocationName { get; set; }
        public int PickUpLocationId { get; set; }
        public string? DropOffLocationName { get; set; }
        public int DropOffLocationId { get; set; }
        public decimal? DailyPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? Status { get; set; }
    }
}
