﻿namespace CarBook_OnionArch.Domain.Entities
{
    public class Car
    {
        public int CarId { get; set; }
        public string? Model { get; set; }
        public int Mileage { get; set; }
        public string? Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string? Fuel { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? BigImageUrl { get; set; }
        public int BrandId { get; set; }
        public required Brand Brand { get; set; }
        public List<CarFeature>? CarFeatures { get; set; }
        public List<CarDescription>? CarDescriptions { get; set; }
        public List<CarPricing>? CarPricings { get; set; }

    }
}
