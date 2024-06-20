using Microsoft.EntityFrameworkCore;
using SocialNetwork.Application;
using SocialNetwork.Application.DTO;
using SocialNetwork.Application.Exceptions;
using SocialNetwork.Application.UseCases.Commands.Users;
using SocialNetwork.DataAccess;
using SocialNetwork.Domain;
using SocialNetwork.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Implementation.UseCases.Commands.Users
{
    public class EfAddUserRelationCommand : IAddUserRelationCommand
    {
        private SocialNetworkContext _context;
        private IApplicationActor _actor;
        public EfAddUserRelationCommand(SocialNetworkContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }
        public int Id => 13;

        public string Name => "Add user as friend";

        public void Execute(AddUserRelationDto data)
        {
            var requests = _context.UserRelations.Where(x => x.SenderId == _actor.Id || x.ReceiverId == _actor.Id);
            var userFromReq = _context.Users.FirstOrDefault(x => x.Id == data.ReceiverId);
            if(userFromReq == null)
            {
                throw new EntityNotFoundException("Receiver does not exist");
            }
            if (requests.Any(x => x.SenderId == _actor.Id && x.ReceiverId == data.ReceiverId  && x.IsAccepted == false) ||
                requests.Any(x => x.ReceiverId == _actor.Id && x.SenderId == data.ReceiverId && x.IsAccepted == false))
            {
                throw new ConflictException("Request already sent");
            }

            if (requests.Any(x => x.SenderId == _actor.Id && x.ReceiverId == data.ReceiverId && x.IsAccepted == true) ||
                requests.Any(x => x.ReceiverId == _actor.Id && x.SenderId == data.ReceiverId && x.IsAccepted == true))
            {
                throw new ConflictException("Users are already friends.");
            }

            UserRelation userRelation = new UserRelation
            {
                SenderId = _actor.Id,
                ReceiverId = data.ReceiverId
            };

            _context.UserRelations.Add(userRelation);
            _context.SaveChanges();
        }
    }
}
