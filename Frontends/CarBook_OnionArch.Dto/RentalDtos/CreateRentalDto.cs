namespace CarBook_OnionArch.Dto.RentalDtos
{
    public class CreateRentalDto
    {
        public int CarId { get; set; }
        public int? UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PickUpLocationId { get; set; }
        public int DropOffLocationId { get; set; }
        public decimal? DailyPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? Status { get; set; }
    }
}
