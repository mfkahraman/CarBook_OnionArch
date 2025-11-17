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
        public Review[]? reviews { get; set; }

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
            public Feature? feature { get; set; }
            public bool isAvailable { get; set; }
        }
        public class Feature
        {
            public int id { get; set; }
            public string? name { get; set; }
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

        public class Review
        {
            public int id { get; set; }
            public int userId { get; set; }
            public int carId { get; set; }
            public string? comment { get; set; }
            public int rating { get; set; }
            public DateTime createDate { get; set; }
            public User? user { get; set; }
        }

        public class User
        {
            public int id { get; set; }
            public required string firstName { get; set; }
            public required string lastName { get; set; }
            public required string email { get; set; }
            public string? passwordHash { get; set; }
            public string? imagePath { get; set; }
            public DateTime createdDate { get; set; }
            public DateTime? updatedDate { get; set; }
        }

    }
}
