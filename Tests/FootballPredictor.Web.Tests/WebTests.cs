namespace FootballPredictor.Web.Tests
{
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc.Testing;

    using Xunit;

    public class WebTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> server;

        public WebTests(WebApplicationFactory<Startup> server)
        {
            this.server = server;
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Home/Privacy")]
        public async Task HomeControllerReturnSuccsessStatusCode(string url)
        {
            var client = this.server.CreateClient();
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/Matches/Fixtures")]
        [InlineData("/Matches/Results")]
        public async Task MatchesControllerReturnSuccsessStatusCode(string url)
        {
            var client = this.server.CreateClient();
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
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

        [Theory]
        [InlineData("/Teams/Squad")]
        [InlineData("/Teams/Team")]
        public async Task TeamsControllerReturnSuccsessStatusCode(string url)
        {
            var client = this.server.CreateClient();
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/Users/Rankings")]
        [InlineData("/Users/PointsByUser")]
        public async Task UsersControllerReturnSuccsessStatusCode(string url)
        {
            var client = this.server.CreateClient();
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/Players/Rankings")]
        public async Task PlayersControllerReturnSuccsessStatusCode(string url)
        {
            var client = this.server.CreateClient();
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/Standings/Leagues")]
        [InlineData("/Standings/EnglishPremierLeague")]
        [InlineData("/Standings/GermanBundesliga")]
        [InlineData("/Standings/ItalianSerieA")]
        [InlineData("/Standings/SpainPrimeraDivision")]
        public async Task StandingsControllerReturnSuccsessStatusCode(string url)
        {
            var client = this.server.CreateClient();
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/Predictions/All")]
        [InlineData("/Predictions/Create")]
        [InlineData("/Predictions/MyPredictions")]
        [InlineData("/Predictions/Edit")]
        public async Task PredictionsControllerReturnSuccsessStatusCode(string url)
        {
            var client = this.server.CreateClient();
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
        //[Fact(Skip = "Example test. Disabled for CI.")]
        //public async Task IndexPageShouldReturnStatusCode200WithTitle()
        //{
        //    var client = this.server.CreateClient();
        //    var response = await client.GetAsync("/");
        //    response.EnsureSuccessStatusCode();
        //    var responseContent = await response.Content.ReadAsStringAsync();
        //    Assert.Contains("<title>", responseContent);
        //}
        //
        //[Fact(Skip = "Example test. Disabled for CI.")]
        //public async Task AccountManagePageRequiresAuthorization()
        //{
        //    var client = this.server.CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });
        //    var response = await client.GetAsync("Identity/Account/Manage");
        //    Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        //}
    }
}
