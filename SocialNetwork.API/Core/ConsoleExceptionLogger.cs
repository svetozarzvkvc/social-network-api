using SocialNetwork.Application;
using SocialNetwork.DataAccess;
using SocialNetwork.Domain;

namespace SocialNetwork.API.Core
{
    public class ConsoleExceptionLogger : IExceptionLogger
    {
        public Guid Log(Exception ex, IApplicationActor actor)
        {
            var id = Guid.NewGuid();
            Console.WriteLine(ex.Message + " ID: " + id);

            return id;
        }
    }

    public class DbExceptionLogger : IExceptionLogger
    {
        private readonly SocialNetworkContext _context;

        public DbExceptionLogger(SocialNetworkContext context)
        {
            _context = context;
        }

        public Guid Log(Exception ex, IApplicationActor actor)
        {
            Guid id = Guid.NewGuid();
            ErrorLog log = new()
            {
                ErrorId = id,
                Message = ex.Message,
                StrackTrace = ex.StackTrace,
                Time = DateTime.UtcNow
            };


            _context.ErrorLogs.Add(log);

            _context.SaveChanges();

            return id;
        }
    }
}
