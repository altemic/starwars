using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace Tests.StarWars
{
    [TestFixture]
    public class IntegrationTests
    {
        [Test]
        public async Task ApiShouldRespondWithOK()
        {
            using var httpClient = new HttpClient();
            
            var request = new HttpRequestMessage(HttpMethod.Get, new Uri("https://swapi.dev/api/films/"));

            var response = await httpClient.SendAsync(request);

            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.OK);
        }
    }
}
