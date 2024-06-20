using Microsoft.EntityFrameworkCore;
using SocialNetwork.Application;
using SocialNetwork.Application.DTO;
using SocialNetwork.Application.Exceptions;
using SocialNetwork.Application.UseCases.Commands.Users;
using SocialNetwork.DataAccess;
using SocialNetwork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Implementation.UseCases.Commands.Users
{
    public class EfRejectUserRequestCommand : IRejectUserRequestCommand
    {
        private SocialNetworkContext _context;
        private IApplicationActor _actor;
        public EfRejectUserRequestCommand(SocialNetworkContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }
        public int Id => 15;

        public string Name => "Reject user request";

        public void Execute(RejectUserRequestDto data)
        {
            var requests = _context.UserRelations.Where(x => x.ReceiverId == _actor.Id);
            var usersRelation = requests.FirstOrDefault(x => x.SenderId == data.RejectedUserId);
            if(data.RejectedUserId < 1)
            {
                throw new ArgumentOutOfRangeException("Rejected user id is not valid");
            }
            if (usersRelation == null)
            {
                throw new EntityNotFoundException("User did not send you a request");
            }
            if (requests.Any(x => x.ReceiverId == _actor.Id && x.SenderId == data.RejectedUserId && x.IsAccepted == true))
            {
                throw new ConflictException("Request is already accepted, you are friend with the user.");
            }
            _context.UserRelations.Remove(usersRelation);
            _context.SaveChanges();
        }
    }
}
