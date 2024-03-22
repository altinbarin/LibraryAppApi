using Business.Constants;
using Entities.Dtos.Book;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.BookValidators
{
    public class BookCreateDTOValidator:AbstractValidator<BookCreateDTO>
    {
        public BookCreateDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(Messages.ThisFieldIsRequired)
                .NotNull().WithMessage(Messages.ThisFieldIsRequired)
                .MaximumLength(100).WithMessage(Messages.MaximumLengthIs100)
                .MinimumLength(1).WithMessage(Messages.MinimumLengthIs1);

            RuleFor(x => x.TotalStock).NotEmpty().WithMessage(Messages.ThisFieldIsRequired).Must(x=>x>0).WithMessage(Messages.TotalStockMustBeGreaterOrEqualToZero);

            RuleFor(x => x.Section).NotEmpty().WithMessage(Messages.ThisFieldIsRequired)
                .NotNull().WithMessage(Messages.ThisFieldIsRequired)
                .MaximumLength(100).WithMessage(Messages.MaximumLengthIs100)
                .MinimumLength(1).WithMessage(Messages.MinimumLengthIs1);
        }
    }
}
