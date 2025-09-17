using FluentValidation;

namespace Dlplone.LMS.DTO.Infrastructure.Validators
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("UserName Should not be empty"); 
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password Should not be empty");
        }
    }
}
