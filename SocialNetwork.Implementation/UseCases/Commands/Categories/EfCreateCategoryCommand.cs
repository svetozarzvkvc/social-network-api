using FluentValidation;
using SocialNetwork.Application;
using SocialNetwork.Application.DTO;
using SocialNetwork.Application.Exceptions;
using SocialNetwork.Application.UseCases.Commands.Categories;
using SocialNetwork.DataAccess;
using SocialNetwork.Domain;
using SocialNetwork.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Implementation.UseCases.Commands.Categories
{
    public class EfCreateCategoryCommand : ICreateCategoryCommand
    {
        private SocialNetworkContext _context;
        private CreateCategoryDtoValidator _validator;
        private IApplicationActor _actor;

        public EfCreateCategoryCommand(SocialNetworkContext context, CreateCategoryDtoValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 1;

        public string Name => "Create category";

        public void Execute(CreateCategoryDTO data)
        {
            if(_actor.Role != "Admin")
            {
                throw new UnauthorizedUseCaseException(this.Name, _actor.Username);
            }

            _validator.ValidateAndThrow(data);

            Category categoryToAdd = new Category
            {
                Name = data.Name,
                ParentId = data.ParentId
            };

            _context.Categories.Add(categoryToAdd);

            var childCategories = _context.Categories
                                          .Where(c => data.ChildIds.Contains(c.Id))
                                          .ToList();

            categoryToAdd.Children = childCategories;

            _context.SaveChanges();
        }
    }
}
