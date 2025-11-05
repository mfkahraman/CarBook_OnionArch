namespace CarBook_OnionArch.Application.Interfaces
{
    public interface IStatisticsRepository
    {
        Task<int> GetCarCountAsync(CancellationToken cancellationToken);
        Task<int> GetLocationCountAsync(CancellationToken cancellationToken);
        Task<int> GetAuthorCountAsync(CancellationToken cancellationToken);
        Task<int> GetBlogCountAsync(CancellationToken cancellationToken);
        Task<int> GetBrandCountAsync(CancellationToken cancellationToken);
        Task<decimal> GetAverageDailyRentPriceAsync(CancellationToken cancellationToken);
        Task<decimal> GetAverageWeeklyRentPriceAsync(CancellationToken cancellationToken);
        Task<decimal> GetAverageMonthlyRentPriceAsync(CancellationToken cancellationToken);
        Task<int> GetAutomaticTransmissionCarCountAsync(CancellationToken cancellationToken);
        Task<string> GetBrandWithMostCarsNameAsync(CancellationToken cancellationToken);
        Task<string> GetBlogWithMostCommentsTitleAsync(CancellationToken cancellationToken);
        Task<int> GetCarCountUnder1000KmAsync(CancellationToken cancellationToken);
        Task<int> GetGasolineCarCountAsync(CancellationToken cancellationToken);
        Task<int> GetDieselCarCountAsync(CancellationToken cancellationToken);
        Task<string> GetCarWithHighestDailyRentPriceNameAsync(CancellationToken cancellationToken);
        Task<string> GetCarWithLowestYearlyRentPriceNameAsync(CancellationToken cancellationToken);
    }
}
