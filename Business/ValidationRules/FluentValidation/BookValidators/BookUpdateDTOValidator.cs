using Business.Constants;
using Entities.Dtos.Book;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.BookValidators
{
    public class BookUpdateDTOValidator:AbstractValidator<BookUpdateDTO>
    {
        public BookUpdateDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(Messages.ThisFieldIsRequired)
                .NotNull().WithMessage(Messages.ThisFieldIsRequired)
                .MaximumLength(100).WithMessage(Messages.MaximumLengthIs100)
                .MinimumLength(1).WithMessage(Messages.MinimumLengthIs1);

            RuleFor(x => x.Section).NotEmpty().WithMessage(Messages.ThisFieldIsRequired)
               .NotNull().WithMessage(Messages.ThisFieldIsRequired)
               .MaximumLength(100).WithMessage(Messages.MaximumLengthIs100)
               .MinimumLength(1).WithMessage(Messages.MinimumLengthIs1);


        }
    }
}
