using FluentValidation;

namespace Dlplone.LMS.DTO.Infrastructure.Validators
{
    public class DoctorValidator : AbstractValidator<DoctorInsertDto>
    {
        public DoctorValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name Should not be empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password Should not be empty");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Should not be empty");
            RuleFor(x => x.UserType).GreaterThan(0).WithMessage("UserType Should not be empty");
        }
    }
}
