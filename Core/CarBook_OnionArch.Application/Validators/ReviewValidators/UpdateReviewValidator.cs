using CarBook_OnionArch.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;

namespace CarBook_OnionArch.Application.Validators.ReviewValidators
{
    // Sealed for tiny perf gain (no subclassing needed)
    public sealed class UpdateReviewValidator : AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id 0'dan büyük olmalıdır.");

            RuleFor(x => x.UserId)
                .GreaterThan(0)
                .WithMessage("UserId 0'dan büyük olmalıdır.");

            RuleFor(x => x.CarId)
                .GreaterThan(0)
                .WithMessage("CarId 0'dan büyük olmalıdır.");

            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5)
                .WithMessage("Rating 1 ile 5 arasında olmalıdır.");


            RuleFor(x => x.CreateDate)
                .Must(d => d <= DateTime.UtcNow)
                .WithMessage("CreateDate gelecekte olamaz.");

            RuleFor(x => x.Comment)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Yorum alanı boş olamaz.")
                .Must(c => !string.IsNullOrWhiteSpace(c)).WithMessage("Yorum alanı boşluk olamaz.")
                .Length(5, 1000).WithMessage("Comment 5-1000 karakter olmalıdır.");
        }
    }
}
