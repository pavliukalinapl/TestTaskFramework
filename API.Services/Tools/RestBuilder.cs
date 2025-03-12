using Newtonsoft.Json;
using RestSharp;
using Tests.Tools.Logger.interfaces;

namespace API.Services.Tools
{
    /// <summary>
    /// A builder for constructing and executing REST API requests using RestSharp
    /// Supports method chaining to define HTTP method, endpoint, parameters, and request body ect
    /// Includes logging capabilities for request execution and error handling which could be extended
    /// </summary>
    public sealed class RestBuilder
    {
        private Func<RestRequest, RestRequest> configFunction;
        private readonly RestClient client;

        public RestBuilder(RestClient client)
        {
            configFunction = (nothing) => (nothing);
            this.client = client;
        }

        public static Func<A, C> Compose<A, B, C>(Func<A, B> f1, Func<B, C> f2)
        {
            return (a) => f2(f1(a));
        }

        public RestRequest Build()
        {
            return configFunction(new RestRequest());
        }

        public RestBuilder Method(Method method)
        {
            configFunction = Compose(configFunction, (request) =>
            {
                request.Method = method;
                return request;
            });
            return this;
        }

        public RestBuilder ToEndPoint(string resource)
        {
            configFunction = Compose(configFunction, (request) =>
            {
                request.Resource = resource;
                return request;
            });
            return this;
        }

        public RestBuilder AddBody(object contractObject)
        {
            configFunction = Compose(configFunction, (request) =>
            {
                request.AddJsonBody(contractObject);
                return request;
            });
            return this;
        }

        public RestBuilder AddParameter(string param, string value)
        {
            configFunction = Compose(configFunction, (request) =>
            {
                request.AddParameter(param, value);
                return request;
            });
            return this;
        }

        public async Task<RestResponse<T>> ExecWithLogging<T>(ILog logger) where T : new()
        {
            RestResponse<T> response = default;
            RestRequest request = Build();
            try
            {
                response = await client.ExecuteAsync<T>(request);
            }
            catch (JsonSerializationException ex)
            {
                logger.Log($"Exception {ex} occured, failed to deserialize response object {typeof(T).FullName}: {response?.Content}");
            }
            finally
            {
                logger.Log($"Request Resource: {request.Resource}");
                logger.Log($"Request Method: {request.Method}");
                logger.Log($"Response StatusCode: {response.StatusCode}");
                //ect.
            }
            return response!;
        }
    }
}