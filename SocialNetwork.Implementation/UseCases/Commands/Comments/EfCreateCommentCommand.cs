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
    public class EfCreateCommentCommand : ICreateCommentCommand
    {
        private SocialNetworkContext _context;
        private CreateCommentDtoValidator _validator;
        private IApplicationActor _actor;

        public EfCreateCommentCommand(SocialNetworkContext context, CreateCommentDtoValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 10;

        public string Name => "Comment a post";

        public void Execute(CreateCommentDto data)
        {

            var post = _context.Posts.Include(x => x.Author).FirstOrDefault(x => x.Id == data.PostId && x.IsActive == true);
            if (!post.Author.SentRequests.Any(x => x.SenderId == post.AuthorId && x.ReceiverId == data.AuthorId && x.IsAccepted == true) &&
                !post.Author.ReceivedRequests.Any(x => x.ReceiverId == post.AuthorId && x.SenderId == data.AuthorId && x.IsAccepted == true))
            {
                throw new ConflictException("Users are not friends.");
            }

            _validator.ValidateAndThrow(data);



            Comment comm = new Comment
            {
                Text = data.Text,
                PostId = data.PostId,
                UserId = _actor.Id,
                ParentId = data.ParentId
            };
            _context.Comment.Add(comm);
            _context.SaveChanges();
        }
    }
}
