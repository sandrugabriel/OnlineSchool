using Newtonsoft.Json;
using OnlineSchool.Courses.Dto;
using OnlineSchool.Courses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Teste.Courses.Helpers;
using Teste.Infrastucture;

namespace Teste.Courses.UnitTests
{
    public class TestCourseIntegration : IClassFixture<ApiWebApplicationFactory>
    {

        private readonly HttpClient _client;

        public TestCourseIntegration(ApiWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllCourses_CoursesFound_ReturnsOkStatusCode_ValidResponse()
        {
            var createCourseRequest = TestCourseFactory.CreateCourse(1);
            var content = new StringContent(JsonConvert.SerializeObject(createCourseRequest), Encoding.UTF8, "application/json");
            await _client.PostAsync("/api/v1/ControllerCourse/createCourse", content);

            var response = await _client.GetAsync("/api/v1/ControllerCourse/all");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetCourseById_CourseFound_ReturnsOkStatusCode_ValidResponse()
        {
            var createCourseRequest = TestCourseFactory.CreateCourse(2);
            var content = new StringContent(JsonConvert.SerializeObject(createCourseRequest), Encoding.UTF8, "application/json");
            await _client.PostAsync("/api/v1/Course/create", content);

            var response = await _client.GetAsync("/api/v1/ControllerCourse/findById/2");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetCourseById_CourseNotFound_ReturnsNotFoundStatusCode()
        {
            var response = await _client.GetAsync("/api/v1/ControllerCourse/findById/9999");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Post_Create_ValidRequest_ReturnsCreatedStatusCode()
        {
            var request = "/api/v1/ControllerCourse/createCourse";
            var ControllerCourse = new CreateRequestCourse { Name = "New Course 1", Department ="asd"};
            var content = new StringContent(JsonConvert.SerializeObject(ControllerCourse), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(request, content);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Course>(responseString);

            Assert.NotNull(result);
            Assert.Equal(ControllerCourse.Name, result.Name);
        }

        [Fact]
        public async Task Put_Update_ValidRequest_ReturnsAcceptedStatusCode()
        {
            var request = "/api/v1/ControllerCourse/createCourse";
            var createCourse =new CreateRequestCourse { Name = "New Course 1", Department = "asd"};
            var content = new StringContent(JsonConvert.SerializeObject(createCourse), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(request, content);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Course>(responseString)!;

            request = "/api/v1/ControllerCourse/updateCourse";
            var updateCourse = new UpdateRequestCourse { Name = "New Course 3", Department ="tes" };
            content = new StringContent(JsonConvert.SerializeObject(updateCourse), Encoding.UTF8, "application/json");

            response = await _client.PutAsync(request, content);

            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);

            responseString = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<Course>(responseString)!;

            Assert.Equal(updateCourse.Name, result.Name);
        }

        [Fact]
        public async Task Put_Update_InvalidCourseName_ReturnsBadRequestStatusCode()
        {
            var request = "/api/v1/ControllerCourse/createCourse";
            var createCourse = new CreateRequestCourse { Name = "test", Department = "asd" };
            var content = new StringContent(JsonConvert.SerializeObject(createCourse), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(request, content);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<DtoCourseView>(responseString)!;

            request = "/api/v1/ControllerCourse/updateCourse";
            var updateCourse = new UpdateRequestCourse { Name = "test", Department = "tes" };
            content = new StringContent(JsonConvert.SerializeObject(updateCourse), Encoding.UTF8, "application/json");

            response = await _client.PutAsync(request, content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Put_Update_CourseDoesNotExist_ReturnsNotFoundStatusCode()
        {
            var request = "/api/v1/ControllerCourse/updateCourse";
            var updateCourse = new UpdateRequestCourse { Name = "New Course 3", Department = "tes" };
            var content = new StringContent(JsonConvert.SerializeObject(updateCourse), Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(request, content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Delete_Delete_CourseExists_ReturnsDeletedCourse()
        {
            var request = "/api/v1/ControllerCourse/createCourse";
            var createCourse = new CreateRequestCourse { Name = "New Course 1", Department = "asd" };
            var content = new StringContent(JsonConvert.SerializeObject(createCourse), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(request, content);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Course>(responseString)!;

            request = $"/api/v1/ControllerCourse/deleteCourse/{result.Id}";

            response = await _client.DeleteAsync(request);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Delete_Delete_CourseDoesNotExist_ReturnsNotFoundStatusCode()
        {
            var request = "/api/v1/ControllerCourse/deleteCourse/77777";

            var response = await _client.DeleteAsync(request);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
