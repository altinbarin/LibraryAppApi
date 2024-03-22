using Business.Constants;
using Entities.Dtos.Member;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation.MemberValidators
{
    public class MemberUpdateDTOValidator: AbstractValidator<MemberUpdateDTO>
    {
        public MemberUpdateDTOValidator()
        {
            RuleFor(name => name.Name).NotEmpty().WithMessage(Messages.ThisFieldIsRequired)
                .MaximumLength(50).WithMessage(Messages.MaximumLengthIs50)
                .MinimumLength(2).WithMessage(Messages.MinimumLengthIs2)
                .Must(IsLetter).WithMessage(Messages.AllCharactersMustBeLetter);

            RuleFor(surname => surname.Surname).NotEmpty().WithMessage(Messages.ThisFieldIsRequired)
                .Must(IsLetter).WithMessage(Messages.AllCharactersMustBeLetter)
                .MaximumLength(50).WithMessage(Messages.MaximumLengthIs50)
                .MinimumLength(2).WithMessage(Messages.MinimumLengthIs2);

            RuleFor(tckno => tckno.TCKNO).NotEmpty().WithMessage(Messages.ThisFieldIsRequired)
                .Must(IsValidTcKimlikNo).WithMessage(Messages.NotAValidTCKNO);

            RuleFor(email => email.Email).NotEmpty().WithMessage(Messages.ThisFieldIsRequired)
                .EmailAddress().WithMessage(Messages.InvalidEmail)
                .MaximumLength(100).WithMessage(Messages.MaximumLengthIs100);

            RuleFor(phoneNumber => phoneNumber.Phone)
           .NotEmpty().WithMessage(Messages.ThisFieldIsRequired)
           .Must(IsValidPhoneNumber).WithMessage(Messages.NotAValidPhoneNumber);

            RuleFor(address => address.Address).NotEmpty().WithMessage(Messages.ThisFieldIsRequired)
               .MaximumLength(250).WithMessage(Messages.MaximumLengthIs250)
               .MinimumLength(10).WithMessage(Messages.MinimumLengthIs10);
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            string RegexValue = @"^(0(\d{10}))$";
            Match matching = Regex.Match(phoneNumber, RegexValue, RegexOptions.IgnoreCase);
            return matching.Success;
        }

        private bool IsLetter(string arg)
        {
            foreach (var item in arg)
            {
                if (!char.IsLetter(item))
                    return false;
            }
            return true;
        }


        private bool IsValidTcKimlikNo(string tcNumber)
        {
            // TC numarası uzunluğunun 11 olması gerekiyor.
            if (tcNumber.Length != 11)
            {
                return false;
            }

            // TC numarasının tüm karakterleri sayı olmalıdır.
            for (int i = 0; i < 11; i++)
            {
                if (!char.IsDigit(tcNumber[i]))
                {
                    return false;
                }
            }

            // TC numarasının ilk hanesi 0 olamaz.
            if (tcNumber[0] == '0')
            {
                return false;
            }

            // TC numarasının son hanesi, ilk 10 hanenin doğru bir şekilde hesaplanması sonucu elde edilen kontrol rakamı olmalıdır.
            int[] tcNumberArray = new int[11];
            for (int i = 0; i < 11; i++)
            {
                tcNumberArray[i] = int.Parse(tcNumber[i].ToString());
            }
            int sumFirstTenDigits = tcNumberArray[0] + tcNumberArray[1] + tcNumberArray[2] + tcNumberArray[3] + tcNumberArray[4] + tcNumberArray[5] + tcNumberArray[6] + tcNumberArray[7] + tcNumberArray[8] + tcNumberArray[9];
            int controlDigit = (sumFirstTenDigits % 10);
            if (controlDigit != tcNumberArray[10])
            {
                return false;
            }

            return true;

        }
    }
}
