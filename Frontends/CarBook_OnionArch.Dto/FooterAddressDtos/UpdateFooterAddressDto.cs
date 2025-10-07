namespace CarBook_OnionArch.Dto.FooterAddressDtos
{
    public class UpdateFooterAddressDto
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public required string Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
