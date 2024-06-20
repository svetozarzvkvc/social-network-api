using SocialNetwork.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.UseCases.Queries.Posts
{
    public interface IGetPostQuery : IQuery<PostDto, int>
    {
    }
}
