using SocialNetwork.Application;

namespace SocialNetwork.API.Core
{
    public interface IExceptionLogger
    {
        Guid Log(Exception ex, IApplicationActor actor);
    }
}
