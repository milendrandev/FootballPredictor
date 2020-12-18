using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FootballPredictor.Web.Tests
{
    public class MiniLegueControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> server;

        public MiniLegueControllerTests(WebApplicationFactory<Startup> server)
        {
            this.server = server;
        }

        [Theory]
        [InlineData("/MiniLigues/All")]
        [InlineData("/MiniLigues/Create")]
        [InlineData("/MiniLigues/Dashboard")]
        public async Task MiniLiguesControllerReturnSuccsessStatusCode(string url)
        {
            var client = this.server.CreateClient();
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}
