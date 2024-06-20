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
    public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDTO>
    {
        private SocialNetworkContext _context;
        public CreateCategoryDtoValidator(SocialNetworkContext context)
        {
            _context = context;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name).NotNull()
                                .WithMessage("Category name is required.")
                                .MinimumLength(3)
                                .WithMessage("Min number of characters is 3.")
                                .Must(name => !_context.Categories.Any(c => c.Name == name))
                                .WithMessage("Category name is in use.");

            RuleFor(x => x.ParentId).Must(CategoryExistsWhenNotNull)
                                    .WithMessage("Parent id doesn't exist.");

            RuleFor(x => x.ChildIds).Must(AllChildrenExist).WithMessage("Not all child categories exist in database.");

        }

        private bool AllChildrenExist(IEnumerable<int> ids)
        {
            if (ids == null || !ids.Any())
            {
                return true;
            }
            int brojIzBaze = _context.Categories.Count(x => x.IsActive && ids.Contains(x.Id));
            return brojIzBaze == ids.Count();

        }

        private bool CategoryExistsWhenNotNull(int? parentId)
        {
            if (!parentId.HasValue)
            {
                return true;
            }

            return _context.Categories.Any(x => x.Id == parentId && x.IsActive);
        }
    }
}
