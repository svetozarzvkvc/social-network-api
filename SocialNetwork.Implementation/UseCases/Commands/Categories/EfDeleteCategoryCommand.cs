using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Application;
using SocialNetwork.Application.DTO;
using SocialNetwork.Application.Exceptions;
using SocialNetwork.Application.UseCases.Commands.Categories;
using SocialNetwork.DataAccess;
using SocialNetwork.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Implementation.UseCases.Commands.Categories
{
    public class EfDeleteCategoryCommand : IDeleteCategoryCommand
    {
        private SocialNetworkContext _context;
        private IApplicationActor _actor;

        public EfDeleteCategoryCommand(SocialNetworkContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }

        public int Id => 3;

        public string Name => "Delete category";

        public void Execute(DeleteCategoryDto data)
        {

            if (data.Id < 1)
            {
                throw new ArgumentOutOfRangeException("Category is not valid.");
            }

            var category = _context.Categories.Include(x => x.Children).FirstOrDefault(x => x.Id == data.Id);

            if (category == null)
            {
                throw new EntityNotFoundException("Category does not exist.");
            }

            if (category.Children.Any())
            {
                throw new ForeignKeyConstraintException("Category has children linked to it");
            }

            if (category.Posts.Any())
            {
                throw new ForeignKeyConstraintException("Category has posts linked to it");
            }

            if (_actor.Role != "Admin")
            {
                throw new UnauthorizedUseCaseException(this.Name, _actor.Username);
            }
            category.IsActive = false;
            _context.SaveChanges();

        }
    }
}
