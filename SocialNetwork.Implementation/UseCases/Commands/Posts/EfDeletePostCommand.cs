using Azure.Core;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Application;
using SocialNetwork.Application.DTO;
using SocialNetwork.Application.Exceptions;
using SocialNetwork.Application.UseCases.Commands.Posts;
using SocialNetwork.DataAccess;
using SocialNetwork.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Implementation.UseCases.Commands.Posts
{
    public class EfDeletePostCommand : IDeletePostCommand
    {
        private SocialNetworkContext _context;
        private IApplicationActor _actor;
        public EfDeletePostCommand(SocialNetworkContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }
        public int Id => 6;

        public string Name => GetType().Name;

        public void Execute(DeletePostDto data)
        {

            if (data.Id < 1)
            {
                throw new ArgumentOutOfRangeException("PostId is not valid.");
            }
            
            var post = _context.Posts.Include(x => x.Author).FirstOrDefault(x => x.Id == data.Id);

            if (post == null)
            {
                throw new EntityNotFoundException("Post does not exist.");
            }

            if (_actor.Role != "Admin")
            {
                if (_actor.Id != post.Author.Id)
                {
                    throw new UnauthorizedUseCaseException(this.Name, _actor.Username);
                }

            }
            //post.IsActive = false;
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }
    }
}
