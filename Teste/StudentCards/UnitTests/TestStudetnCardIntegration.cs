using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Teste.Infrastucture;
using Test.StudentCards.Helpers;

namespace Teste.StudentCards.UnitTests
{
    public class TestStudetnCardIntegration : IClassFixture<ApiWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public TestStudetnCardIntegration(ApiWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllStudentCards_StudentCardsFound_ReturnsOkStatusCode()
        {
            var createStudentCardRequest = TestStudentCardFactory.CreateStudentCard(1);
            var content = new StringContent(JsonConvert.SerializeObject(createStudentCardRequest), Encoding.UTF8, "application/json");
            await _client.GetAsync("/api/v1/ControllerStudentCard/all");

            var response = await _client.GetAsync("/api/v1/ControllerStudentCard/all");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetAllStudentCards_StudentCardsNotFound_ReturnsNotFoundStatusCode()
        {
            var response = await _client.GetAsync("/api/v1/ControllerStudentCard/all");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetStudentCardById_StudentCardFound_ReturnsOkStatusCode_ValidResponse()
        {
            var createStudentCardRequest = TestStudentCardFactory.CreateStudentCard(2);
            var content = new StringContent(JsonConvert.SerializeObject(createStudentCardRequest), Encoding.UTF8, "application/json");
            await _client.PostAsync("/api/v1/ControllerStudentCard/create", content);

            var response = await _client.GetAsync("api/v1/ControllerStudentCard/findById/1");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetStudentCardById_StudentCardNotFound_ReturnsNotFoundStatusCode()
        {
            var response = await _client.GetAsync("/api/v1/ControllerStudentCard/1");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

    }
}
