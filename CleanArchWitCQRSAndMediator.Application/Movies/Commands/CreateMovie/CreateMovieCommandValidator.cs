using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchWitCQRSAndMediator.Application.Movies.Commands.CreateMovie
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(v => v.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characteres");

            RuleFor(v => v.Description)
                .NotEmpty().WithMessage("Description is required")
                .MaximumLength(300).WithMessage("Title must not exceed 300 characteres");

            RuleFor(v => v.Author)
                .NotEmpty().WithMessage("Author is required")
                .MaximumLength(20).WithMessage("Author must not exceed 20 characteres");
        }
    }
}
