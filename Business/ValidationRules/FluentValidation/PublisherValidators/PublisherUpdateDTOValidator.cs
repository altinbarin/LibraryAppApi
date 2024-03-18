using Business.Constants;
using Entities.Dtos.Publisher;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.PublisherValidators
{
    public class PublisherUpdateDTOValidator:AbstractValidator<PublisherUpdateDTO>
    {
        public PublisherUpdateDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(Messages.ThisFieldIsRequired)
               .NotNull().WithMessage(Messages.ThisFieldIsRequired)
               .MaximumLength(100).WithMessage(Messages.MaximumLengthIs100)
               .MinimumLength(1).WithMessage(Messages.MinimumLengthIs1);

            RuleFor(x => x.Address).NotEmpty().WithMessage(Messages.ThisFieldIsRequired)
                .NotNull().WithMessage(Messages.ThisFieldIsRequired)
                .MaximumLength(100).WithMessage(Messages.MaximumLengthIs200)
                .MinimumLength(1).WithMessage(Messages.MinimumLengthIs1);

            RuleFor(x => x.Phone).NotEmpty().WithMessage(Messages.ThisFieldIsRequired)
                .NotNull().WithMessage(Messages.ThisFieldIsRequired)
                .Length(11).WithMessage(Messages.LengthIs11)
                .Must(IsDigit).WithMessage(Messages.NumberOnly);

            RuleFor(x => x.Email).NotEmpty().WithMessage(Messages.ThisFieldIsRequired)
                .NotNull().WithMessage(Messages.ThisFieldIsRequired)
                .MaximumLength(100).WithMessage(Messages.MaximumLengthIs100)
                .MinimumLength(1).WithMessage(Messages.MinimumLengthIs1)
                .EmailAddress().WithMessage(Messages.InvalidEmail);
        }

        private bool IsDigit(string phoneNumber)
        {
            if (phoneNumber.ToString().All(char.IsDigit))
            {
                return true;
            }
            return false;
        }
    }
}
