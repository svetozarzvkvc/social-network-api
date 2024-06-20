using SocialNetwork.Application;
using SocialNetwork.DataAccess;
using SocialNetwork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Implementation
{
    public class BasicAuthorizationApplicationActorProvider : IApplicationActorProvider
    {
        private string _authorizationHeader;
        private SocialNetworkContext _context;

        public BasicAuthorizationApplicationActorProvider(string authorizationHeader, SocialNetworkContext context)
        {
            _authorizationHeader = authorizationHeader;
            _context = context;
        }

        public IApplicationActor GetActor()
        {
            if (_authorizationHeader == null || !_authorizationHeader.Contains("Basic"))
            {
                return new UnauthorizedActor();
            }

            var base64Data = _authorizationHeader.Split(" ")[1];


            var bytes = Convert.FromBase64String(base64Data);

            var decodedCredentials = System.Text.Encoding.UTF8.GetString(bytes);

            if (decodedCredentials.Split(":").Length < 2)
            {
                throw new InvalidOperationException("Invalid Basic authorization header.");
            }

            string username = decodedCredentials.Split(":")[0];
            string password = decodedCredentials.Split(":")[1];

            User u = _context.Users.FirstOrDefault(x => x.UserName == username && x.Password == password);

            if (u == null)
            {
                return new UnauthorizedActor();
            }

            return new Actor
            {
                Email = u.Email,
                FirstName = u.FirstName,
                Id = u.Id,
                LastName = u.LastName,
                Username = u.UserName,
                Role = u.Role.Name
            };
        }
    }
}
