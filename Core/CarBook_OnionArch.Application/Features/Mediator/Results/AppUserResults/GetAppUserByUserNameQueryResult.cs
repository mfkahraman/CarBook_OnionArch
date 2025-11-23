namespace CarBook_OnionArch.Application.Features.Mediator.Results.AppUserResults
{
    public class GetAppUserByUserNameQueryResult
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ImagePath { get; set; }
    }
}
