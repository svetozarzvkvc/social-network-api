using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application
{
    public interface IApplicationActorProvider
    {
        IApplicationActor GetActor();
    }
}
