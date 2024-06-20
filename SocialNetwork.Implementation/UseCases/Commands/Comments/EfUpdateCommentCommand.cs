using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Application;
using SocialNetwork.Application.DTO;
using SocialNetwork.Application.Exceptions;
using SocialNetwork.Application.UseCases.Commands.Comments;
using SocialNetwork.DataAccess;
using SocialNetwork.Domain;
using SocialNetwork.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Implementation.UseCases.Commands.Comments
{
    public class EfUpdateCommentCommand : IUpdateCommentCommand
    {
        private SocialNetworkContext _context;
        private UpdateCommentDtoValidator _validator;
        private IApplicationActor _actor;
        public EfUpdateCommentCommand(SocialNetworkContext context, UpdateCommentDtoValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 12;

        public string Name => "Update comment";

        public void Execute(UpdateCommentDto data)
        {
            var comment = _context.Comment.Include(x=>x.User).FirstOrDefault(x => x.Id == data.Id && x.IsActive == true);
            if (comment == null)
            {
                throw new EntityNotFoundException("Comment does not exist");
            }


            if (_actor.Id != comment.User.Id)
            {
                throw new UnauthorizedUseCaseException(this.Name, _actor.Username);
            }

           
            _validator.ValidateAndThrow(data);

            if (data.Text != null)
            {
                comment.Text = data.Text;
            }
            _context.SaveChanges();

        }
    }
}
