using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Application.DTO;
using SocialNetwork.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Implementation.Validators
{
    public class CreateCommentDtoValidator : AbstractValidator<CreateCommentDto>
    {
        private SocialNetworkContext _context;
        public CreateCommentDtoValidator(SocialNetworkContext context)
        {
            _context = context;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.PostId).Must(x => _context.Posts.Any(y => y.Id == x && y.IsActive == true)).WithMessage("Post does not exist");
            RuleFor(x => x.Text).NotNull().WithMessage("Text is required").MaximumLength(100).WithMessage("Max lenght is 100 characters");
            RuleFor(x => x.ParentId).Must(x => !x.HasValue || _context.Comment.Any(y => y.Id == x && y.IsActive == true)).WithMessage("Parent comment does not exist");

        }

    }
}
