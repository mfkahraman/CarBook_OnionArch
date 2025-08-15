namespace CarBook_OnionArch.Dto.CarDtos
{
    public class ResultGetCarByIdDto
    {
            public int id { get; set; }
            public string? model { get; set; }
            public int mileage { get; set; }
            public string? transmission { get; set; }
            public int seat { get; set; }
            public int luggage { get; set; }
            public string? fuel { get; set; }
            public string? coverImageUrl { get; set; }
            public string? bigImageUrl { get; set; }
            public int brandId { get; set; }
    }
}
