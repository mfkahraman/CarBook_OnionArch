using CarBook_OnionArch.Application.Features.Mediator.Commands.AppUserCommands;
using FluentValidation;

namespace CarBook_OnionArch.Application.Validators.AppUserValidators
{
    public class UpdateAppUserValidator : AbstractValidator<UpdateAppUserCommand>
    {
        public UpdateAppUserValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id 0'dan büyük olmalıdır.");

            RuleFor(x => x)
                .Must(x =>
                    !string.IsNullOrWhiteSpace(x.FirstName) ||
                    !string.IsNullOrWhiteSpace(x.LastName) ||
                    !string.IsNullOrWhiteSpace(x.UserName) ||
                    !string.IsNullOrWhiteSpace(x.Email) ||
                    !string.IsNullOrWhiteSpace(x.PasswordHash) ||
                    !string.IsNullOrWhiteSpace(x.ImagePath)
                )
                .WithMessage("En az bir güncellenebilir alan (FirstName, LastName, UserName, Email, PasswordHash, PhoneNumber veya ImagePath) sağlanmalıdır.");

            When(x => !string.IsNullOrWhiteSpace(x.FirstName), () =>
            {
                RuleFor(x => x.FirstName)
                    .Length(2, 50)
                    .WithMessage("Ad (FirstName) 2 ile 50 karakter arasında olmalıdır.");
            });

            When(x => !string.IsNullOrWhiteSpace(x.LastName), () =>
            {
                RuleFor(x => x.LastName)
                    .Length(2, 50)
                    .WithMessage("Soyad (LastName) 2 ile 50 karakter arasında olmalıdır.");
            });

            When(x => !string.IsNullOrWhiteSpace(x.UserName), () =>
            {
                RuleFor(x => x.UserName)
                    .Matches(@"^[a-zA-Z0-9][a-zA-Z0-9_.-]{1,29}$")
                    .WithMessage("Kullanıcı adı (UserName) alfasayısal olmalı, . _ - içerebilir ve uzunluğu 2 ile 30 karakter arasında olmalıdır.");
            });

            When(x => !string.IsNullOrWhiteSpace(x.Email), () =>
            {
                RuleFor(x => x.Email)
                    .EmailAddress()
                    .WithMessage("E-posta geçerli bir e-posta adresi olmalıdır.");
            });

            When(x => !string.IsNullOrWhiteSpace(x.PasswordHash), () =>
            {
                RuleFor(x => x.PasswordHash)
                    .MaximumLength(512)
                    .WithMessage("Şifre hash'i 512 karakteri aşmamalıdır.");
            });


            When(x => !string.IsNullOrWhiteSpace(x.ImagePath), () =>
            {
                RuleFor(x => x.ImagePath)
                    .MaximumLength(260)
                    .WithMessage("ImagePath 260 karakteri aşmamalıdır.");
            });
        }
    }
}
