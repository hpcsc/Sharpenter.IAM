using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Sharpenter.IAM.UI.Web.Tests
{
    public class TestBase
    {
        private readonly HttpClient _client;
        
        protected TestBase()
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Test");
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = server.CreateClient();
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