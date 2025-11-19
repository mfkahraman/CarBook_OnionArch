using CarBook_OnionArch.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;

namespace CarBook_OnionArch.Application.Validators.ReviewValidators
{
    public class UpdateReviewValidator : AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewValidator()
        {
            RuleFor(x=> x.Id).GreaterThan(0).WithMessage("Id 0'dan büyük olmalıdır.");
            RuleFor(x => x.Id).NotNull().WithMessage("Id alanı null olamaz.");
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("UserId 0'dan büyük olmalıdır.");
            RuleFor(x => x.CarId).GreaterThan(0).WithMessage("CarId 0'dan büyük olmalıdır.");
            RuleFor(x => x.Rating).InclusiveBetween(1, 5).WithMessage("Rating 1 ile 5 arasında olmalıdır.");
            RuleFor(x => x.Comment).MaximumLength(1000).WithMessage("Comment maksimum 1000 karakter olabilir.");
            RuleFor(x => x.CreateDate).LessThanOrEqualTo(DateTime.Now).WithMessage("CreateDate gelecekte olamaz.");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Yorum alanı boş olamaz.");
            RuleFor(x => x.UserId).NotNull().WithMessage("UserId alanı null olamaz.");
            RuleFor(x => x.CarId).NotNull().WithMessage("CarId alanı null olamaz.");
            RuleFor(x => x.Rating).NotNull().WithMessage("Rating alanı null olamaz.");
            RuleFor(x => x.CreateDate).NotNull().WithMessage("CreateDate alanı null olamaz.");
            RuleFor(x => x.Comment).Must(comment => !string.IsNullOrWhiteSpace(comment)).WithMessage("Yorum alanı boşluk olamaz.");
            RuleFor(x => x.Comment).MinimumLength(5).WithMessage("Comment minimum 5 karakter olabilir.");
        }
    }
}
