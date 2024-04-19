using FluentValidation;
using Persons.Application.PersonEntity.Commands;
using System.Text.RegularExpressions;

namespace Persons.Application.PersonEntity.Validators
{
    public class CreatePersonValidator : AbstractValidator<CreatePersonCommand>
    {
        const string expression = "[\\d$-/:-?{-~!\"^_`\\[\\]@#]+";
        readonly TimeSpan regexTimeout = TimeSpan.FromMinutes(5);
        public CreatePersonValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .NotNull()
                .Length(3, 50)
                .Custom((name, context) =>
                {
                    bool match = false;
                    try
                    {
                        match = Regex.IsMatch(name, expression, RegexOptions.None, regexTimeout);
                    }
                    catch (RegexMatchTimeoutException)
                    {
                        context.AddFailure("Regular expression timed out.");
                        return;
                    }

                    if (match) context.AddFailure("Invalid characters");
                });
        }
    }
}
