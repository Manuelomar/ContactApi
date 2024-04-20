using FluentValidation;
using Persons.Application.PersonEntity.Commands;
using System.Text.RegularExpressions;

namespace Persons.Application.PersonEntity.Validators
{
    public class CreatePersonValidator : AbstractValidator<CreatePersonCommand>
    {
        const string expression = "[\\d$-/:-?{-~!\"^_`\\[\\]@#]+";
        readonly TimeSpan regexTimeout = TimeSpan.FromMinutes(5);
        const string cedulaRegex = @"^\d{3}-\d{7}-\d{1}$";

        public CreatePersonValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .NotNull()
                .Length(3, 50)
                .Custom((name, context) =>
                {
                    bool match = Regex.IsMatch(name, expression, RegexOptions.None, regexTimeout);
                    if (match) context.AddFailure("Invalid characters");
                });

            RuleFor(x => x.LastName)
                .NotEmpty()
                .NotNull()
                .Length(3, 50)
                .Custom((name, context) =>
                {
                    bool match = Regex.IsMatch(name, expression, RegexOptions.None, regexTimeout);
                    if (match) context.AddFailure("Invalid characters");
                });

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .NotNull()
                .Must(BeAValidDate).WithMessage("BirthDate is required and must be a valid date.");

            RuleFor(x => x.Cedula)
                .NotEmpty()
                .NotNull()
                .Must(BeAValidCedula).WithMessage("Invalid cédula format. Format must be XXX-XXXXXXX-X.");
        }

        private bool BeAValidDate(DateTime date)
        {
            return date != default(DateTime);
        }

        private bool BeAValidCedula(string cedula)
        {
            return Regex.IsMatch(cedula, cedulaRegex);
        }
    }
}
