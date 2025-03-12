using Newtonsoft.Json;

namespace Models.UserService.Request
{
    public class PostUserRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("job")]
        public string Job { get; set; }
    }
}