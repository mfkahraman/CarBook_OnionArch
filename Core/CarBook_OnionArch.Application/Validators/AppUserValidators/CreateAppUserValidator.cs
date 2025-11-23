using CarBook_OnionArch.Application.Features.Mediator.Commands.AppUserCommands;
using FluentValidation;

namespace CarBook_OnionArch.Application.Validators.AppUserValidators
{
    public class CreateAppUserValidator : AbstractValidator<CreateAppUserCommand>
    {
        public CreateAppUserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("İsim boş olamaz.")
                .MaximumLength(50).WithMessage("İsim en fazla 50 karakter olabilir.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyisim boş olamaz.")
                .MaximumLength(50).WithMessage("Soyisim en fazla 50 karakter olabilir.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Kullanıcı adı boş olamaz.")
                .MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("Kullanıcı adı en fazla 50 karakter olabilir.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta adresi boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(x => x.PasswordHash)
                .NotEmpty().WithMessage("Parola boş olamaz.")
                .MinimumLength(6).WithMessage("Parola en az 6 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Parola en fazla 100 karakter olabilir.");

            When(x => !string.IsNullOrWhiteSpace(x.ImagePath), () =>
            {
                RuleFor(x => x.ImagePath)
                    .MaximumLength(260)
                    .WithMessage("ImagePath 260 karakteri aşmamalıdır.");
            });
        }
    }
}
