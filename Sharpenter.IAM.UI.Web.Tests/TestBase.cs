using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sharpenter.IAM.Repository.EntityFramework;
using Xunit;

namespace Sharpenter.IAM.UI.Web.Tests
{
    [Collection("DatabaseCollection")]
    public class TestBase
    {
        private readonly HttpClient _client;

        protected TestBase()
        {
            var server = new TestServer(
                WebHost.CreateDefaultBuilder()
                    .UseEnvironment("Test")
                    .UseStartup<Startup>()
            );
            
            _client = server.CreateClient();
        }

        protected void Execute(Action<IdentityContext> action)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentityContext>().UseSqlServer(Config.TestConnectionString);
            using (var context = new IdentityContext(optionsBuilder.Options))
            {
                action(context);
            }
        }

        protected Task<HttpResponseMessage> Get(string url)
        {
            return _client.GetAsync(url);
        }
        
        protected Task<HttpResponseMessage> Post(string url, dynamic data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"); 
            return _client.PostAsync(url, content);
        }

        protected async Task<JObject> ParseResponse(HttpResponseMessage response)
        {
            var responseString = await response.Content.ReadAsStringAsync();
            return JObject.Parse(responseString);
        }

        protected void AssertSuccessResponse(JObject responseJson)
        {
            Assert.True(responseJson["success"].Value<bool>());
            Assert.Equal(0, responseJson["messages"].AsEnumerable().Count());
        }
    }
}