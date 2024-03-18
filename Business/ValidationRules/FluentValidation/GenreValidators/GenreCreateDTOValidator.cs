using Business.Constants;
using Entities.Dtos.Genre;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.GenreValidators
{
    public class GenreCreateDTOValidator:AbstractValidator<GenreCreateDTO>
    {
        public GenreCreateDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(Messages.ThisFieldIsRequired)
                .NotNull().WithMessage(Messages.ThisFieldIsRequired)
                .MaximumLength(100).WithMessage(Messages.MaximumLengthIs100)
                .MinimumLength(1).WithMessage(Messages.MinimumLengthIs1);
        }
    }
}
