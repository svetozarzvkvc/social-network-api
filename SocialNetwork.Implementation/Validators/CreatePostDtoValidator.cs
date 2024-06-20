using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using SocialNetwork.Application.DTO;
using SocialNetwork.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Implementation.Validators
{
    public class CreatePostDtoValidator : AbstractValidator<CreatePostDto>
    {
        private SocialNetworkContext _context;

        public CreatePostDtoValidator(SocialNetworkContext context)
        {
            _context = context;
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Title).NotNull().WithMessage("Title is required").MaximumLength(100).WithMessage("Max lenght is 100");
            RuleFor(x => x.Description).MaximumLength(200).WithMessage("Max lenght is 200");
            RuleFor(x => x.CategoryId).Must(x => _context.Categories.Any(y => y.Id == x && y.IsActive == true)).WithMessage("Category does not exist");
        }
    }
}
