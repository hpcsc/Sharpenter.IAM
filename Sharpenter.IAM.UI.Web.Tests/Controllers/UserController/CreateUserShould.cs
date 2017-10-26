using System.Threading.Tasks;
using Ploeh.AutoFixture;
using Xunit;

namespace Sharpenter.IAM.UI.Web.Tests.Controllers.UserController
{
    public class CreateUserShould : TestBase
    {
        [Fact]
        public async Task ReturnSuccess_WhenUserIsCreatedSuccessfully()
        {
            var fixture = new Fixture();
            var response = await Post("/api/user", new
            {
                username = fixture.Create<string>(),
                password = fixture.Create<string>()
            });

            response.EnsureSuccessStatusCode();
            var responseJson = await ParseResponse(response);
            AssertSuccessResponse(responseJson);
        }
    }
}