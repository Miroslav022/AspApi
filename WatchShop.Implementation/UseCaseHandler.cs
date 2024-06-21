﻿using System.Diagnostics;
using System.Numerics;
using WatchShop.Application;

namespace WatchShop.Implementation
{
    public class UseCaseHandler
    {
        private readonly IApplicationActor _actor;
        private readonly IUseCaseLogger _logger;
        private static List<int> GloballyAllowed => new List<int> { 1, 24, 23, 26, 29, 30 };
        public UseCaseHandler(IApplicationActor actor, IUseCaseLogger logger)
        {
            _actor = actor;
            _logger = logger;
        }

        public void HandleCommand<TData>(ICommand<TData> command, TData data)
        {
            HandleCrossCuttingConcerns(command, data);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            command.Execute(data);
            stopwatch.Stop();

            Console.WriteLine($"UseCase: {command.Name}, {stopwatch.ElapsedMilliseconds} ms");
        }

        //Query
        public TResult HandleQuery<TResult, TSearch>(IQuery<TResult, TSearch> query, TSearch search)
            where TResult : class

        {
            HandleCrossCuttingConcerns(query, search);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var result = query.Execute(search);

            stopwatch.Stop();

            Console.WriteLine($"UseCase: {query.Name}, {stopwatch.ElapsedMilliseconds} ms");

            return result;
        }
        //CCC
        private void HandleCrossCuttingConcerns(IUseCase useCase, object data)
        {

            if (!_actor.AllowedUseCases.Contains(useCase.Id) && !GloballyAllowed.Contains(useCase.Id))
            {
                throw new UnauthorizedAccessException();
            }

            var log = new UseCaseLog
            {
                UseCaseData = data,
                UseCaseName = useCase.Name,
                Username = _actor.Username,
            };

            _logger.Log(log);
        }
    }
}
