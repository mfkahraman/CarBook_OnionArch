namespace CarBook_OnionArch.Dto.FooterAddressDtos
{
    public class UpdateFooterAddressDto
    {
        public int id { get; set; }
        public required string description { get; set; }
        public required string address { get; set; }
        public string? phone { get; set; }
        public string? email { get; set; }
    }
}
