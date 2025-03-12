using API.Services.Enums;
using API.Services.Services;
using Configuration.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;

namespace API.Tests.Base
{
    /// <summary>
    /// Base test class supporting parallel execution, dependency injection, and configuration management
    /// Initializes required services dynamically based on the test scenario
    /// </summary>
    [Parallelizable(ParallelScope.Fixtures)]
    public class BaseTest : IDisposable
    {
        protected IConfiguration config;
        protected readonly string scenarioId;
        protected IServiceCollection ServiceCollection;
        protected ServiceProvider ServiceProvider;
        private readonly List<ServiceType> requiredServices;

        public BaseTest(string scenarioId, List<ServiceType> requiredServices)
        {
            this.scenarioId = scenarioId;
            this.requiredServices = requiredServices;
            config = new Configurator().GetConfig();
        }

        [OneTimeSetUp]
        public void Initialize()
        {
            ServiceCollection = new ServiceCollection();

            ServiceCollection.AddSingleton<IConfiguration>(config);

            var baseUrl = config.GetSection($"{ConfigKeys.GlobalParameters}")[ConfigKeys.ApiBaseUrl];

            ServiceCollection.AddSingleton(provider =>
                new RestClient(new RestClientOptions
                {
                    BaseUrl = new Uri(baseUrl)
                })
            );

            foreach (var service in requiredServices)
            {
                switch (service)
                {
                    case ServiceType.UserService:
                        ServiceCollection.AddSingleton<UserService>();
                        break;
                }
            }

            ServiceProvider = ServiceCollection.BuildServiceProvider();
        }

        protected T GetService<T>() where T : class
        {
            return ServiceProvider.GetRequiredService<T>();
        }

        [OneTimeTearDown]
        public void Dispose()
        {
            ServiceProvider?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}