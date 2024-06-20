using SocialNetwork.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.UseCases.Commands.Comments
{
    public interface ICreateCommentCommand : ICommand<CreateCommentDto>
    {
    }
}
