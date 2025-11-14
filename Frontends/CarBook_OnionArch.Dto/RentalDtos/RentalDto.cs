namespace CarBook_OnionArch.Dto.RentalDtos
{
    public class RentalDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PickupLocationId { get; set; }
        public int DropoffLocationId { get; set; }
    }
}
