using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Teste.Books.Helpers;
using Teste.Infrastucture;

namespace Teste.Books.UnitTests
{
    public class TestBookIntegration : IClassFixture<ApiWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public TestBookIntegration(ApiWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllBooks_BooksFound_ReturnsOkStatusCode()
        {
            var createBookRequest = TestBookFactory.CreateBook(1);
            var content = new StringContent(JsonConvert.SerializeObject(createBookRequest), Encoding.UTF8, "application/json");
            await _client.GetAsync("/api/v1/ControllerBook/all");

            var response = await _client.GetAsync("/api/v1/ControllerBook/all");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        
        [Fact]
        public async Task GetAllBooks_BooksNotFound_ReturnsNotFoundStatusCode()
        {
            var response = await _client.GetAsync("/api/v1/ControllerBook/all");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetBookById_BookFound_ReturnsOkStatusCode_ValidResponse()
        {
            var createBookRequest = TestBookFactory.CreateBook(2);
            var content = new StringContent(JsonConvert.SerializeObject(createBookRequest), Encoding.UTF8, "application/json");
            await _client.PostAsync("/api/v1/ControllerBook/create", content);

            var response = await _client.GetAsync("api/v1/ControllerBook/findById/1");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetBookById_BookNotFound_ReturnsNotFoundStatusCode()
        {
            var response = await _client.GetAsync("/api/v1/ControllerBook/1");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

    }
}
