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
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, PostSearchCommentsDto>()
                .ForMember(x => x.Id, y => y.MapFrom(u => u.Id))
                .ForMember(x => x.Text, y => y.MapFrom(u => u.Text))
                .ForMember(x => x.AuthorUserName, y => y.MapFrom(u => u.User.UserName))
                .ForMember(x => x.Time, y => y.MapFrom(u => u.CreatedAt));
        }
    }
}