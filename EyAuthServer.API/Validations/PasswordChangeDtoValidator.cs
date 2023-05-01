using EyAuthServer.Core.Dtos;
using FluentValidation;

namespace EyAuthServer.API.Validations
{
    public class PasswordChangeDtoValidator : AbstractValidator<ChangePasswordDto>
    {
        public PasswordChangeDtoValidator() 
        {
            RuleFor(x => x.NewPassword).NotEmpty().WithMessage("NewPassword is required");

            RuleFor(x => x.OldPassword).NotEmpty().WithMessage("OldPassword is required");
        }
    }
}
