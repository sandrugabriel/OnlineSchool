using Microsoft.AspNetCore.Mvc;
using OnlineSchool.Books.Dto;
using OnlineSchool.Books.Models;
using OnlineSchool.Students.Dto;
using OnlineSchool.Students.Models;
using System;

namespace OnlineSchool.Students.Controllers.interfaces
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class ControllerAPIStudent : ControllerBase
    {

        [HttpGet("/all")]
        [ProducesResponseType(statusCode: 200, type: typeof(List<Student>))]
        [ProducesResponseType(statusCode: 400, type: typeof(string))]
        public abstract Task<ActionResult<List<Student>>> GetStudents();

        [HttpGet("/findById")]
        [ProducesResponseType(statusCode: 200, type: typeof(Student))]
        [ProducesResponseType(statusCode: 400, type: typeof(string))]
        public abstract Task<ActionResult<Student>> GetById([FromQuery] int id);

        [HttpGet("/findByName")]
        [ProducesResponseType(statusCode: 200, type: typeof(Student))]
        [ProducesResponseType(statusCode: 400, type: typeof(string))]
        public abstract Task<ActionResult<Student>> GetByName([FromQuery] string name);

        [HttpPost("/createStudent")]
        [ProducesResponseType(statusCode: 201, type: typeof(Student))]
        [ProducesResponseType(statusCode: 400, type: typeof(string))]
        public abstract Task<ActionResult<Student>> CreateStudent(CreateRequestStudent request);

        [HttpPost("/createBook")]
        [ProducesResponseType(statusCode: 201, type: typeof(Book))]
        [ProducesResponseType(statusCode: 400, type: typeof(string))]
        public abstract Task<ActionResult<Book>> CreateBook(CreateRequestBook request);

        [HttpPut("/updateStudent")]
        [ProducesResponseType(statusCode: 200, type: typeof(Student))]
        [ProducesResponseType(statusCode: 400, type: typeof(string))]
        [ProducesResponseType(statusCode: 404, type: typeof(string))]
        public abstract Task<ActionResult<Student>> UpdateStudent([FromQuery] int id, UpdateRequestStudent request);

        [HttpDelete("/deleteStudent")]
        [ProducesResponseType(statusCode: 200, type: typeof(Student))]
        [ProducesResponseType(statusCode: 404, type: typeof(string))]
        public abstract Task<ActionResult<Student>> DeleteStudent([FromQuery] int id);


    }
}
