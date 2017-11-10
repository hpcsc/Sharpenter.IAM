using System.Threading.Tasks;
using Xunit;

namespace Sharpenter.IAM.UI.Web.Tests.Controllers.UsersController
{
    public class ListUsersShould : TestBase
    {
        [Fact]
        public async Task ReturnEmptyResponse_WhenThereIsNoUser()
        {
            var response = await Get("/api/users");
            response.EnsureSuccessStatusCode();

            var responseJson = await ParseResponse(response);
            AssertSuccessResponse(responseJson);
            Assert.False(responseJson["data"].HasValues);
        }
    }
}