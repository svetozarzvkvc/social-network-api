using SocialNetwork.Application.UseCases;
using SocialNetwork.Application;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Implementation
{
    public class UseCaseHandler
    {
        private readonly IApplicationActor _actor;
        private readonly IUseCaseLogger _logger;
        public UseCaseHandler(IApplicationActor actor, IUseCaseLogger logger)
        {
            _actor = actor;
            _logger = logger;
        }
        public void HandleCommand<TData>(ICommand<TData> command, TData data)
        {
            
            if (!_actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedAccessException();
            }

            UseCaseLog log = new UseCaseLog
            {
                UseCaseData = data,
                UseCaseName = command.Name,
                Username = _actor.Username,
            };

            _logger.Log(log);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            command.Execute(data);

            Console.WriteLine($"UseCase: {command.Name}, {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Stop();
        }

        public TResult HandleQuery<TResult, TSearch>(IQuery<TResult,TSearch> query, TSearch search)
            where TResult : class

        {
            
            if (!_actor.AllowedUseCases.Contains(query.Id))
            {
                throw new UnauthorizedAccessException();
            }

            UseCaseLog log = new UseCaseLog
            {
                UseCaseData = search,
                UseCaseName = query.Name,
                Username = _actor.Username,
            };
            _logger.Log(log);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var result = query.Execute(search);

            Console.WriteLine($"UseCase: {query.Name}, {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Stop();

            return result;
        }
    }
}
