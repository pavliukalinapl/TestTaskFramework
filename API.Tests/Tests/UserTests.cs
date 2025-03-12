using API.Services.Enums;
using API.Services.Services;
using API.Tests.Base;
using FluentAssertions;
using System.Net;
using Tests.Data.PayloadBuilders.UserService;

namespace API.Tests.Tests
{
    [TestFixture]
    public class UserTests : BaseTest
    {
        private UserService userService;

        public UserTests() : base(nameof(UserTests),
        [
            ServiceType.UserService
        ])
        { }

        [SetUp]
        public void Setup()
        {
            userService = GetService<UserService>();
        }

        [Test]
        public async Task CreateUser()
        {
            var payload = new UserBuilder()
                .SetName("Jon")
                .SetJob("programmer")
                .Build();

            var response = await userService.PostUser(payload);
            var responseData = response.Data;

            response.StatusCode.Should().Be(HttpStatusCode.Created);
            responseData.Id.Should().NotBeNullOrEmpty();
            responseData.Name.Should().Be(payload.Name);
            responseData.Job.Should().Be(payload.Job);
        }

        [Test]
        public async Task FetchUserList()
        {
            var response = await userService.GetUsers(2);
            var responseData = response.Data;

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            responseData.Data.Count.Should().BeGreaterThan(0);
            responseData.Data[0].Id.Should().BeGreaterThanOrEqualTo(0);
        }
    }
}