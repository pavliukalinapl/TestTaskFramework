using Models.UserService.Request;

namespace Tests.Data.PayloadBuilders.UserService
{
    /// <summary>
    /// Builder class for dynamicly constructing payload for PostUserRequest
    /// </summary>
    public class UserBuilder
    {
        private string name;
        private string job;

        public UserBuilder SetName(string name)
        {
            this.name = name;
            return this;
        }

        public UserBuilder SetJob(string job)
        {
            this.job = job;
            return this;
        }

        public PostUserRequest Build()
        {
            return new PostUserRequest()
            {
                Name = name,
                Job = job
            };
        }
    }
}