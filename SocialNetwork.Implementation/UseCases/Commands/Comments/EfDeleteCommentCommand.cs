using Microsoft.EntityFrameworkCore;
using SocialNetwork.Application;
using SocialNetwork.Application.Exceptions;
using SocialNetwork.Application.UseCases.Commands.Comments;
using SocialNetwork.DataAccess;
using SocialNetwork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Implementation.UseCases.Commands.Comments
{
    public class EfDeleteCommentCommand : IDeleteCommentCommand
    {
        private SocialNetworkContext _context;
        private IApplicationActor _actor;

        public EfDeleteCommentCommand(SocialNetworkContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }
        public int Id => 11;

        public string Name => "Delete comment";

        public void Execute(int data)
        {

            if (data < 1)
            {
                throw new ArgumentOutOfRangeException("Comment is not valid.");
            }
            var comment = _context.Comment.Include(x => x.Children).Include(x => x.User).FirstOrDefault(x => x.Id == data);

            if (_actor.Role != "Admin")
            {
                if (_actor.Id != comment.User.Id)
                {
                    throw new UnauthorizedUseCaseException(this.Name, _actor.Username);
                }
            }


            if (comment == null)
            {
                throw new EntityNotFoundException("Comment does not exist.");
            }

            if (comment.Children.Any())
            {
                throw new ForeignKeyConstraintException("Comment has children linked to it");
            }


            

            comment.IsActive = false;
            _context.SaveChanges();
        }
    }
}
