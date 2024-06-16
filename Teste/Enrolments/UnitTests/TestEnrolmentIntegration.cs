using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Teste.Enrolments.Helpers;
using Teste.Infrastucture;

namespace Teste.Enrolments.UnitTests
{
    public class TestEnrolmentIntegration : IClassFixture<ApiWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public TestEnrolmentIntegration(ApiWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllEnrolments_EnrolmentsFound_ReturnsOkStatusCode()
        {
            var createEnrolmentRequest = TestEnrolmentFactory.CreateEnrolment(1);
            var content = new StringContent(JsonConvert.SerializeObject(createEnrolmentRequest), Encoding.UTF8, "application/json");
            await _client.GetAsync("/api/v1/ControllerEnrolment/all");

            var response = await _client.GetAsync("/api/v1/ControllerEnrolment/all");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetAllEnrolments_EnrolmentsNotFound_ReturnsNotFoundStatusCode()
        {
            var response = await _client.GetAsync("/api/v1/ControllerEnrolment/all");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetEnrolmentById_EnrolmentFound_ReturnsOkStatusCode_ValidResponse()
        {
            var createEnrolmentRequest = TestEnrolmentFactory.CreateEnrolment(2);
            var content = new StringContent(JsonConvert.SerializeObject(createEnrolmentRequest), Encoding.UTF8, "application/json");
            await _client.PostAsync("/api/v1/ControllerEnrolment/create", content);

            var response = await _client.GetAsync("api/v1/ControllerEnrolment/findById/1");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetEnrolmentById_EnrolmentNotFound_ReturnsNotFoundStatusCode()
        {
            var response = await _client.GetAsync("/api/v1/ControllerEnrolment/1");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

    }
}
