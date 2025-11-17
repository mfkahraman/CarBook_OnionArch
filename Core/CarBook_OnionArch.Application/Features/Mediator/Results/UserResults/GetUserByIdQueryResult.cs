namespace CarBook_OnionArch.Application.Features.Mediator.Results.UserResults
{
    public class GetUserByIdQueryResult
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
