namespace CarBook_OnionArch.Dto.ContactDtos
{
    public class ResultContactDto
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? subject { get; set; }
        public string? message { get; set; }
        public DateTime sendDate { get; set; }
    }
}
