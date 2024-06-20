using Newtonsoft.Json;
using SocialNetwork.Application;
using SocialNetwork.Implementation;
using System.IdentityModel.Tokens.Jwt;

namespace SocialNetwork.API.Core
{
    public class JwtApplicationActorProvider: IApplicationActorProvider
    {
        private string authorizationHeader;

        public JwtApplicationActorProvider(string authorizationHeader)
        {
            this.authorizationHeader = authorizationHeader;
        }

        public IApplicationActor GetActor()
        {
            if (authorizationHeader.Split("Bearer ").Length != 2)
            {
                return new UnauthorizedActor();
            }

            string token = authorizationHeader.Split("Bearer ")[1];

            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(token);

            var claims = tokenObj.Claims;

            var claim = claims.First(x => x.Type == "jti").Value;

            var actor = new Actor
            {
                Email = claims.First(x => x.Type == "UserName").Value,
                Username = claims.First(x => x.Type == "UserName").Value,
                FirstName = claims.First(x => x.Type == "FirstName").Value,
                LastName = claims.First(x => x.Type == "LastName").Value,
                Role = claims.First(x=>x.Type == "Role").Value,
                Id = int.Parse(claims.First(x => x.Type == "Id").Value)
            };

            return actor;
        }
    }
}
