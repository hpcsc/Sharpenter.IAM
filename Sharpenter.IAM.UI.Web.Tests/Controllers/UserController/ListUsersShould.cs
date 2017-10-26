using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Sharpenter.IAM.UI.Web.Tests.Controllers.UserController
{
    public class ListUsersShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        
        public ListUsersShould()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task ReturnEmptyResponse_WhenThereIsNoUser()
        {
            var response = await _client.GetAsync("/api/user");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var responseJson = JObject.Parse(responseString);
            Assert.True(responseJson["success"].Value<bool>());
            Assert.Equal(0, responseJson["messages"].AsEnumerable().Count());
            Assert.Null(responseJson["data"]);
        }
    }
}