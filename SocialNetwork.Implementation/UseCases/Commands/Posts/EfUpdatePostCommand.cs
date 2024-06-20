using FluentValidation;
using SocialNetwork.Application;
using SocialNetwork.Application.DTO;
using SocialNetwork.Application.Exceptions;
using SocialNetwork.Application.UseCases.Commands.Posts;
using SocialNetwork.DataAccess;
using SocialNetwork.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Implementation.UseCases.Commands.Posts
{
    public class EfUpdatePostCommand : IUpdatePostCommand
    {
        private SocialNetworkContext _context;
        private UpdatePostDtoValidator _validator;
        private IApplicationActor _actor;
        public EfUpdatePostCommand(SocialNetworkContext context, UpdatePostDtoValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 9;

        public string Name => "Update post";

        public void Execute(UpdatePostDto data)
        {
            var post = _context.Posts.FirstOrDefault(x => x.Id == data.Id && x.IsActive == true);

            if (post == null)
            {
                throw new EntityNotFoundException("Post does not exist");
            }
            if(_actor.Role != "Admin")
            {
                if (_actor.Id != post.AuthorId)
                {
                    throw new UnauthorizedUseCaseException(this.Name, _actor.Username);
                }
            }
            

            
            _validator.ValidateAndThrow(data);

            if (data.Title != null)
            {
                post.Title = data.Title;
            }
            if (data.Description != null)
            {
                post.Description = data.Description;

            }
            if (data.CategoryId.HasValue)
            {
                post.CategoryId = data.CategoryId.Value;

            }
            _context.SaveChanges();
        }
    }
}
