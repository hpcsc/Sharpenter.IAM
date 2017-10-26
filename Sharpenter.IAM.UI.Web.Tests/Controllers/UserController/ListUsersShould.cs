using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Sharpenter.IAM.UI.Web.Tests.Controllers.UserController
{
    public class ListUsersShould : TestBase
    {
        [Fact]
        public async Task ReturnEmptyResponse_WhenThereIsNoUser()
        {
            var response = await Get("/api/user");
            response.EnsureSuccessStatusCode();

            var responseJson = await ParseResponse(response);
            AssertSuccessResponse(responseJson);
            Assert.Null(responseJson["data"]);
        }
    }
}