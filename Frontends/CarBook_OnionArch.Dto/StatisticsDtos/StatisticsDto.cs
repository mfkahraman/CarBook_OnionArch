namespace CarBook_OnionArch.Dto.StatisticsDtos
{
    public class StatisticsDto
    {
        public int AuthorCount { get; set; }
        public int AutomaticTransmissionCarCount { get; set; }
        public decimal AverageDailyRentPrice { get; set; }
        public decimal AverageMonthlyRentPrice { get; set; }
        public decimal AverageWeeklyRentPrice { get; set; }
        public int BlogCount { get; set; }
        public string? BlogWithMostCommentsTitle { get; set; }
        public int BrandCount { get; set; }
        public string? BrandWithMostCarsName { get; set; }
        public int CarCount { get; set; }
        public int CarCountUnder1000Km { get; set; }
        public string? CarWithHighestDailyRentPriceName { get; set; }
        public string? CarWithLowestYearlyRentPriceName { get; set; }
        public int DieselCarCount { get; set; }
        public int GasolineCarCount { get; set; }
        public int LocationCount { get; set; }
    }
}
