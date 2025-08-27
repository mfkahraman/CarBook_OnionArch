namespace CarBook_OnionArch.Dto.CarDtos
{
    public class ResultCarWithRelationsDto
    {
        public int id { get; set; }
        public string? model { get; set; }
        public int mileage { get; set; }
        public string? transmission { get; set; }
        public byte seat { get; set; }
        public byte luggage { get; set; }
        public string? fuel { get; set; }
        public string? coverImageUrl { get; set; }
        public string? bigImageUrl { get; set; }
        public int brandId { get; set; }
        public Brand? brand { get; set; }
        public Carfeature[]? carFeatures { get; set; }
        public Cardescription[]? carDescriptions { get; set; }
        public Carpricing[]? carPricings { get; set; }

        public class Brand
        {
            public int id { get; set; }
            public string? name { get; set; }
        }

        public class Carfeature
        {
            public int id { get; set; }
            public int carId { get; set; }
            public int featureId { get; set; }
            public object? feature { get; set; }
            public bool isAvailable { get; set; }
        }

        public class Cardescription
        {
            public int id { get; set; }
            public string? detail { get; set; }
            public int carId { get; set; }
        }

        public class Carpricing
        {
            public int id { get; set; }
            public int carId { get; set; }
            public int pricingId { get; set; }
            public Pricing? pricing { get; set; }
            public decimal amount { get; set; }
        }

        public class Pricing
        {
            public int id { get; set; }
            public string? name { get; set; }
        }

    }
}
