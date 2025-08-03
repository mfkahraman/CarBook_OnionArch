namespace CarBook_OnionArch.Domain.Entities
{
    public class CarDescription
    {
        public int CarDescriptionId { get; set; }
        public required string Detail { get; set; }
        public int CarId { get; set; }
        public required Car Car { get; set; }
    }
}
