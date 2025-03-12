using API.Services.Base;
using API.Services.Tools;
using Microsoft.Extensions.Configuration;
using Models.UserService.Request;
using Models.UserService.Response;
using RestSharp;

namespace API.Services.Services
{
    /// <summary>
    /// Service class for handling user-related API requests
    /// </summary>
    public class UserService : RestService
    {
        private readonly RestBuilder restBuilder;

        public UserService(IConfiguration config, RestClient restClient)
            : base(config, restClient)
        {
            restBuilder = new RestBuilder(restClient);
        }

        public Task<RestResponse<UserResponse>> PostUser(PostUserRequest payload)
        {
            return restBuilder
                .Method(Method.Post)
                .ToEndPoint("/api/users")
            .AddBody(payload)
                .ExecWithLogging<UserResponse>(logger);
        }

        public Task<RestResponse<UserListResponse>> GetUsers(int page)
        {
            return restBuilder
                .Method(Method.Get)
                .ToEndPoint($"/api/users")
                .AddParameter("page", page.ToString())
                .ExecWithLogging<UserListResponse>(logger);
        }
    }
}