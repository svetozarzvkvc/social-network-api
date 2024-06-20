using FluentValidation;
using SocialNetwork.Application.DTO;
using SocialNetwork.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Implementation.Validators
{
    public class UpdateCommentDtoValidator : AbstractValidator<UpdateCommentDto>
    {
        private SocialNetworkContext _context;
        public UpdateCommentDtoValidator(SocialNetworkContext context)
        {

            _context = context;
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Text).NotNull().WithMessage("Text can not be empty")
                .MaximumLength(100).WithMessage("Max lenght is 100 characters");



        }
    }
}
