using Newtonsoft.Json;
using WatchShop.Application;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;

namespace watchShopApi.Core
{
    public class DbUseCaseLogger : IUseCaseLogger
    {
        private readonly AspContext _context;

        public DbUseCaseLogger(AspContext context)
        {
            _context = context;
        }
        public void Log(WatchShop.Application.UseCaseLog log)
        {
            WatchShop.Domain.Entities.UseCaseLog newLog = new WatchShop.Domain.Entities.UseCaseLog
            {
                UseCaseName = log.UseCaseName,
                Username = log.Username,
                UseCaseData = JsonConvert.SerializeObject(log.UseCaseData),
                ExecutedAt = DateTime.UtcNow
            };


            _context.UseCaseLogs.Add(newLog);
            _context.SaveChanges();
        }
    }
}
