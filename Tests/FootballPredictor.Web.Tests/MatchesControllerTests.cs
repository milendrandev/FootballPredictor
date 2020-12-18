using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FootballPredictor.Web.Tests
{
    public class MatchesControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> server;

        public MatchesControllerTests(WebApplicationFactory<Startup> server)
        {
            this.server = server;
        }

        [Theory]
        [InlineData("/Matches/Fixtures")]
        [InlineData("/Matches/Results")]
        [InlineData("/Matches/Simulate")]
        [InlineData("/Matches/UserPoints")]

        public async Task MatchesControllerReturnSuccsessStatusCode(string url)
        {
            var client = this.server.CreateClient();
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}
