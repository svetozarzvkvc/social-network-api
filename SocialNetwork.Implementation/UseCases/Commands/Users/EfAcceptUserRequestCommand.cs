using SocialNetwork.Application;
using SocialNetwork.Application.DTO;
using SocialNetwork.Application.Exceptions;
using SocialNetwork.Application.UseCases.Commands.Users;
using SocialNetwork.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Implementation.UseCases.Commands.Users
{
    public class EfAcceptUserRequestCommand : IAcceptUserRequestCommand
    {
        private SocialNetworkContext _context;
        private IApplicationActor _actor;
        public EfAcceptUserRequestCommand(SocialNetworkContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }
        public int Id => 14;

        public string Name => "Accept user request";

        public void Execute(AcceptUserRequestDto data)
        {
            var requests = _context.UserRelations.Where(x => x.ReceiverId == _actor.Id);
            var usersRelation = requests.FirstOrDefault(x => x.SenderId == data.AcceptingUserId);
            if (usersRelation == null)
            {
                throw new EntityNotFoundException("User did not send you a request");
            }
            if (requests.Any(x => x.ReceiverId == _actor.Id && x.SenderId == data.AcceptingUserId && x.IsAccepted == true))
            {
                throw new ConflictException("Request is already accepted, you are friend with the user.");
            }
                usersRelation.AcceptedDate = DateTime.UtcNow;
                usersRelation.IsAccepted = true;
                _context.SaveChanges();       
        }
    }
}
