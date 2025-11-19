using CarBook_OnionArch.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;

namespace CarBook_OnionArch.Application.Validators.ReviewValidators
{
    public class CreateReviewValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId 0'dan büyük olmalıdır.");

            RuleFor(x => x.CarId)
                .GreaterThan(0).WithMessage("CarId 0'dan büyük olmalıdır.");

            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5).WithMessage("Rating 1 ile 5 arasında olmalıdır.");

            RuleFor(x => x.CreateDate)
                .LessThanOrEqualTo(_ => DateTime.Now).WithMessage("CreateDate gelecekte olamaz.");

            RuleFor(x => x.Comment)
                .NotNull().WithMessage("Yorum alanı null olamaz.")
                .Must(c => !string.IsNullOrWhiteSpace(c)).WithMessage("Yorum alanı boşluk olamaz.")
                .MinimumLength(5).WithMessage("Comment minimum 5 karakter olabilir.")
                .MaximumLength(1000).WithMessage("Comment maksimum 1000 karakter olabilir.");
        }
    }
}
