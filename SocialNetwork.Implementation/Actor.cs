using SocialNetwork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Implementation
{
    public class Actor : IApplicationActor
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Role { get; set; }
        public IEnumerable<int> AllowedUseCases => new List<int> { 1,3,4,5,6,7,8,9,10,11,12,13,14,15};

    }

    public class UnauthorizedActor : IApplicationActor
    {
        public int Id => 0;

        public string Username => "unauthorized";

        public string Email => "/";

        public string FirstName => "unauthorized";

        public string LastName => "unauthorized";
        public string Role => "unauthorized";
        public IEnumerable<int> AllowedUseCases => new List<int> { 2 };

    }
}
