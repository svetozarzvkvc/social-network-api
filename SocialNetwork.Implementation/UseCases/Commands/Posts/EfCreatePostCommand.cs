using FluentValidation;
using SocialNetwork.Application;
using SocialNetwork.Application.DTO;
using SocialNetwork.Application.UseCases.Commands.Posts;
using SocialNetwork.DataAccess;
using SocialNetwork.Domain;
using SocialNetwork.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Implementation.UseCases.Commands.Posts
{
    public class EfCreatePostCommand : ICreatePostCommand
    {
        private SocialNetworkContext _context;
        private CreatePostDtoValidator _validator;
        private IApplicationActor _actor;
        public EfCreatePostCommand(SocialNetworkContext context, CreatePostDtoValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 5;

        public string Name => "Create post";

        public void Execute(CreatePostDto data)
        {
            _validator.ValidateAndThrow(data);

            foreach (var file in data.Files)
            {
                var tempFile = Path.Combine("wwwroot", "temp", file);
                var destinationFile = Path.Combine("wwwroot", "posts", file);
                System.IO.File.Move(tempFile, destinationFile);
            }

           

            Post postToAdd = new Post
            {
                Title = data.Title,
                Description = data.Description,
                AuthorId = _actor.Id,
                CategoryId = data.CategoryId,
                PostFiles = data.Files.Select(x =>
                {

                    var fileExtension = Path.GetExtension(x);
                    var fileType = fileExtension == ".mp4" ? FileType.Video : FileType.Image;

                    return new PostFile
                    {
                        File = new Domain.File
                        {
                            Path = x,
                            Type = fileType
                        }
                    };
                }).ToList()
            };

            _context.Posts.Add(postToAdd);

           

            _context.SaveChanges();
        }
    }
}
