using Microsoft.Extensions.Configuration;

namespace API.Services.Base
{
    /// <summary>
    /// Abstract base class for services
    /// </summary>
    public abstract class BaseService : IDisposable
    {
        protected readonly IConfiguration config;

        public BaseService(IConfiguration config)
        {
            this.config = config;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}