namespace CarBook_OnionArch.Application.Interfaces
{
    public interface IStatisticsRepository
    {
        Task<int> GetCarCountAsync();
        Task<int> GetLocationCountAsync();
        Task<int> GetAuthorCountAsync();
        Task<int> GetBlogCountAsync();
        Task<int> GetBrandCountAsync();
        Task<decimal> GetAverageDailyRentPriceAsync();
        Task<decimal> GetAverageWeeklyRentPriceAsync();
        Task<decimal> GetAverageMonthlyRentPriceAsync();
        Task<int> GetAutomaticTransmissionCarCountAsync();
        Task<string> GetBrandWithMostCarsNameAsync();
        Task<string> GetBlogWithMostCommentsTitleAsync();
        Task<int> GetCarCountUnder1000KmAsync();
        Task<int> GetGasolineCarCountAsync();
        Task<int> GetElectricCarCountAsync();
        Task<string> GetCarWithHighestDailyRentPriceNameAsync();
        Task<string> GetCarWithLowestDailyRentPriceNameAsync();
    }
}
