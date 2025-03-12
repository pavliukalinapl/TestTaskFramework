using Microsoft.Extensions.Configuration;
using RestSharp;
using Tests.Tools.Logger;
using Tests.Tools.Logger.enums;
using Tests.Tools.Logger.interfaces;

namespace API.Services.Base
{
    /// <summary>
    /// Base service for API interactions using RestSharp
    /// </summary>
    public class RestService : BaseService
    {
        private readonly RestClient restClient;
        protected ILog logger;

        public RestService(IConfiguration config, RestClient restClient)
            : base(config)
        {
            this.restClient = restClient;
            logger = LoggerFactory.CreateLogger(LoggerType.Api);
        }

        public RestClient GetRestClient() => restClient;
    }
}