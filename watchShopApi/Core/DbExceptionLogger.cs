using WatchShop.Application;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;

namespace watchShopApi.Core
{
    public class DbExceptionLogger : IExceptionLogger
    {
        private readonly AspContext _aspContext;

        public DbExceptionLogger(AspContext aspContext)
        {
            _aspContext = aspContext;
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

            _aspContext.ErrorLogs.Add(log);

            _aspContext.SaveChanges();

            return id;
        }
    }
}
