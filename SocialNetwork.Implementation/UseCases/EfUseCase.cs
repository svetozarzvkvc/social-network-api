using SocialNetwork.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        private readonly SocialNetworkContext _context;

        protected EfUseCase(SocialNetworkContext context)
        {
            _context = context;
        }

        protected SocialNetworkContext Context => _context;
    }
}
