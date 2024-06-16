using Newtonsoft.Json;
using OnlineSchool.Students.Dto;
using OnlineSchool.Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Teste.Infrastucture;
using Test.Students.Helpers;

namespace Teste.Students.UnitTests
{
    public class TestStudentIntegration : IClassFixture<ApiWebApplicationFactory>
    {


        private readonly HttpClient _client;

        public TestStudentIntegration(ApiWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllStudents_StudentsFound_ReturnsOkStatusCode_ValidResponse()
        {
            var createStudentRequest = TestStudentFactory.CreateStudent(1);
            var content = new StringContent(JsonConvert.SerializeObject(createStudentRequest), Encoding.UTF8, "application/json");
            await _client.PostAsync("/api/v1/ControllerStudent/createStudent", content);

            var response = await _client.GetAsync("/api/v1/ControllerStudent/all");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetStudentById_StudentFound_ReturnsOkStatusCode_ValidResponse()
        {
            var createStudentRequest = TestStudentFactory.CreateStudent(2);
            var content = new StringContent(JsonConvert.SerializeObject(createStudentRequest), Encoding.UTF8, "application/json");
            await _client.PostAsync("/api/v1/Student/create", content);

            var response = await _client.GetAsync("/api/v1/ControllerStudent/findById/2");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetStudentById_StudentNotFound_ReturnsNotFoundStatusCode()
        {
            var response = await _client.GetAsync("/api/v1/ControllerStudent/findById/9999");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Post_Create_ValidRequest_ReturnsCreatedStatusCode()
        {
            var request = "/api/v1/ControllerStudent/createStudent";
            var ControllerStudent = new CreateRequestStudent { Name = "New Student 1", Age = 18, Email="asd@gma.cm" };
            var content = new StringContent(JsonConvert.SerializeObject(ControllerStudent), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(request, content);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Student>(responseString);

            Assert.NotNull(result);
            Assert.Equal(ControllerStudent.Name, result.Name);
        }

        [Fact]
        public async Task Put_Update_ValidRequest_ReturnsAcceptedStatusCode()
        {
            var request = "/api/v1/ControllerStudent/createStudent";
            var createStudent = new CreateRequestStudent { Name = "New Student 1", Age = 18, Email = "asd@gma.cm" };
            var content = new StringContent(JsonConvert.SerializeObject(createStudent), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(request, content);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Student>(responseString)!;

            request = "/api/v1/ControllerStudent/updateStudent";
            var updateStudent = new UpdateRequestStudent { Name = "New Student 3", Age = 18, Email = "asd@gma.cm" };
            content = new StringContent(JsonConvert.SerializeObject(updateStudent), Encoding.UTF8, "application/json");

            response = await _client.PutAsync(request, content);

            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);

            responseString = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<Student>(responseString)!;

            Assert.Equal(updateStudent.Name, result.Name);
        }

        [Fact]
        public async Task Put_Update_InvalidStudentName_ReturnsBadRequestStatusCode()
        {
            var request = "/api/v1/ControllerStudent/createStudent";
            var createStudent = new CreateRequestStudent { Name = "test", Age = 18, Email = "asd@gma.cm" };
            var content = new StringContent(JsonConvert.SerializeObject(createStudent), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(request, content);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<DtoStudentView>(responseString)!;

            request = "/api/v1/ControllerStudent/updateStudent";
            var updateStudent = new UpdateRequestStudent { Name = "test",
                Age = 10,
                Email = "asd@gma.cm" };
            content = new StringContent(JsonConvert.SerializeObject(updateStudent), Encoding.UTF8, "application/json");

            response = await _client.PutAsync(request, content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Put_Update_StudentDoesNotExist_ReturnsNotFoundStatusCode()
        {
            var request = "/api/v1/ControllerStudent/updateStudent";
            var updateStudent = new UpdateRequestStudent { Name = "New Student 3", Age = 18, Email = "asd@gma.cm" };
            var content = new StringContent(JsonConvert.SerializeObject(updateStudent), Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(request, content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Delete_Delete_StudentExists_ReturnsDeletedStudent()
        {
            var request = "/api/v1/ControllerStudent/createStudent";
            var createStudent = new CreateRequestStudent { Name = "New Student 1", Age = 18, Email = "asd@gma.cm" };
            var content = new StringContent(JsonConvert.SerializeObject(createStudent), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(request, content);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<DtoStudentView>(responseString)!;

            request = $"/api/v1/ControllerStudent/deleteStudent/{result.Id}";

            response = await _client.DeleteAsync(request);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Delete_Delete_StudentDoesNotExist_ReturnsNotFoundStatusCode()
        {
            var request = "/api/v1/ControllerStudent/deleteStudent/77777";

            var response = await _client.DeleteAsync(request);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
