using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Enviroments.Test
{
    public class UnitTest1
    {
        private readonly HttpClient _client;
        private static string Enviroment {get;set;}

        public UnitTest1()
        {
            _client = TestServerContext.Client("Test");
        }

        [Fact]
        public async void Test1()
        {
            var response = await _client.GetAsync("/");
            var teste = await response.Content.ReadAsStringAsync();
            Assert.Equal("53439-240;Rua do teste;longe de pertinho", teste);
           // Assert.Equal("3", TestServerContext.Configuration.GetValue<string>("Teste"));
        }


    }
}
