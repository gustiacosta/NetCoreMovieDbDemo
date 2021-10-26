using DotNetCoolMovies.Core.Models;
using FluentValidation;

namespace DotNetCoolMovies.Infrastructure.Validators
{
    public class ModelValidators
    {
        public class MovieModelValidator : AbstractValidator<MovieModel>
        {
            public MovieModelValidator()
            {
                RuleFor(x => x.Title)
                    .NotEmpty().WithMessage("Movie title must be provided")
                    .Length(50).WithMessage($"Title length must be {0} max.");

                RuleFor(x => x.Year)
                    .NotEmpty().WithMessage("Movie year must be provided")
                    .GreaterThan(1900).WithMessage("Movie is too old");
            }
        }
    }
}
