using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ploeh.AutoFixture;
using Sharpenter.IAM.Core;
using Xunit;

namespace Sharpenter.IAM.UI.Web.Tests.Controllers.UsersController
{
    public class CreateUserShould : TestBase
    {
        private readonly dynamic _parameters;

        public CreateUserShould()
        {
            var fixture = new Fixture();
            _parameters = new
            {
                username = fixture.Create<string>(),
                password = fixture.Create<string>()
            };
            
            Execute(context => context.Database.ExecuteSqlCommand("truncate table [User]"));
        }
        
        [Fact]
        public async Task ReturnSuccess_WhenUserIsCreatedSuccessfully()
        {
            var response = await Post("/api/users", _parameters);

            response.EnsureSuccessStatusCode();
            var responseJson = await ParseResponse(response);
            AssertSuccessResponse(responseJson);
        }
        
        [Fact]
        public async Task AddUserToDatabase_WhenUserIsCreatedSuccessfully()
        {
            var response = await Post("/api/users", _parameters);

            response.EnsureSuccessStatusCode();

            Execute(context =>
            {
                var users = context.Set<User>().ToList();
                Assert.Equal(1, users.Count);
                Assert.Equal(_parameters.username, users.First().Username);
            });
        }
    }
}