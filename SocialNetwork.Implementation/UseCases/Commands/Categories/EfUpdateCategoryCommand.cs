using FluentValidation;
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
    public class EfUpdateCategoryCommand : IUpdateCategoryCommand
    {
        private SocialNetworkContext _context;
        private UpdateCategoryDtoValidator _validator;
        private IApplicationActor _actor;
        public EfUpdateCategoryCommand(SocialNetworkContext context, UpdateCategoryDtoValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 4;

        public string Name => "Update category";

        public void Execute(UpdateCategoryDto data)
        {
            
            if(_actor.Role != "Admin")
            {
                throw new UnauthorizedUseCaseException(this.Name, _actor.Username);
            }
            var objBaza = _context.Categories.FirstOrDefault(x => x.Id == data.Id);

            if(objBaza == null)
            {
                throw new EntityNotFoundException("Category does not exist");
            }

            _validator.ValidateAndThrow(data);


            if (data.Name != null)
            {
                objBaza.Name = data.Name;
            }
            if (data.ParentId.HasValue)
            {
                objBaza.ParentId = data.ParentId.Value;
            }
            if (data.ChildrenIds != null && data.ChildrenIds.Count > 0)
            {
                foreach (var item in objBaza.Children)
                {
                    objBaza.Children.Remove(item);
                }
                foreach (var childId in data.ChildrenIds)
                {
                    var child = _context.Categories.Find(childId);
                    if (child != null)
                    {
                        objBaza.Children.Add(child);
                    }
                }
            }
            _context.SaveChanges();
        }
    }
}
