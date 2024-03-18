using Business.Constants;
using Entities.Dtos.Author;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.AuthorValidatiors
{
    public class AuthorUpdateDTOValidator:AbstractValidator<AuthorUpdateDTO>
    {
        public AuthorUpdateDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(Messages.ThisFieldIsRequired)
                 .NotNull().WithMessage(Messages.ThisFieldIsRequired)
                 .MaximumLength(100).WithMessage(Messages.MaximumLengthIs100)
                 .MinimumLength(1).WithMessage(Messages.MinimumLengthIs1);

            RuleFor(x => x.Surname).NotEmpty().WithMessage(Messages.ThisFieldIsRequired)
                .NotNull().WithMessage(Messages.ThisFieldIsRequired)
                .MaximumLength(100).WithMessage(Messages.MaximumLengthIs100)
                .MinimumLength(1).WithMessage(Messages.MinimumLengthIs1);
        }
    }
}
