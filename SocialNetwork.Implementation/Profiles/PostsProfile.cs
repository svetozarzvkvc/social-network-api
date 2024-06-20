using AutoMapper;
using SocialNetwork.Application.DTO;
using SocialNetwork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Implementation.Profiles
{
    public class PostsProfile : Profile
    {
        public PostsProfile()
        {
            CreateMap<Post, SearchPostResult>()
                .ForMember(x => x.Author, y => y.MapFrom(p => p.Author.UserName))
                .ForMember(x => x.CommentsCount, y => y.MapFrom(p => p.Comments.Count))
                .ForMember(x => x.Title, y => y.MapFrom(p => p.Title))
                .ForMember(x => x.CreatedAt, y => y.MapFrom(p => p.CreatedAt))
                .ForMember(x => x.Id, y => y.MapFrom(p => p.Id))
                .ForMember(x => x.Comments, y => y.MapFrom(p => p.Comments.Select(x => new PostSearchCommentsDto
                {
                    Text = x.Text,
                    AuthorUserName = x.User.UserName,
                    Time = x.CreatedAt
                })));
        }
    }
}
