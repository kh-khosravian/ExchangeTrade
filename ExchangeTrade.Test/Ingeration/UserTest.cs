using ExchangeTrade.Logic.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;
using Xunit;

namespace ExchangeTrade.Test.Ingeration
{
    public class UserTest
    {
        public HttpClient Client { get; private set; }

        public UserTest()
        {
            var server = new TestServer(new WebHostBuilder().UseEnvironment("Development").UseConfiguration(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build())
                .UseStartup<Startup>());

            Client = server.CreateClient();
        }

        [Fact]
        public async void User_GetExistingUser_RetunUserInfo()
        {

            var response = await Client.GetAsync("api/user?username=khosravian@outlook.com");
            var content = JsonConvert.DeserializeObject<UserModel>(response.Content.ReadAsStringAsync().Result);

            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(content);
            Assert.Equal("khosravian@outlook.com", content.Email);
        }

        [Fact]
        public async void User_GetExistingUser_RetunNotFound()
        {
            var response = await Client.GetAsync("api/user?username=khosravian1@outlook.com");

            Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
