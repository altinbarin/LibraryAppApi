using Business.Constants;
using Entities.Dtos.BorrowedBook;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.BorrowedBookValidators
{
    public class BorrowedBookCreateDTOValidator:AbstractValidator<BorrowedBookCreateDTO>
    {
        public BorrowedBookCreateDTOValidator()
        {
            RuleFor(borrowedBookCreateDto => borrowedBookCreateDto.BookId).NotEmpty().NotNull().WithMessage(Messages.ThisFieldIsRequired);
            RuleFor(borrowedBookCreateDto => borrowedBookCreateDto.MemberId).NotEmpty().NotNull().WithMessage(Messages.ThisFieldIsRequired);



        }
    }
}
