namespace CarBook_OnionArch.Domain.Entities
{
    public class Brand
    {
        public int BrandId { get; set; }
        public required string Name { get; set; }
        public List<Car>? Cars { get; set; }
    }
}
