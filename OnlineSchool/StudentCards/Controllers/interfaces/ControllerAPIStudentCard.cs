
using Microsoft.AspNetCore.Mvc;
using OnlineSchool.StudentCards.Dto;
using OnlineSchool.StudentCards.Models;

namespace OnlineSchool.StudentCards.Controllers.interfaces
{
    [ApiController]
    [Route("api/v1/[controller]/")]
    public abstract class ControllerAPIStudentCard : ControllerBase
    {

        [HttpGet("all")]
        [ProducesResponseType(statusCode: 200, type: typeof(List<StudentCard>))]
        [ProducesResponseType(statusCode: 400, type: typeof(string))]
        public abstract Task<ActionResult<List<StudentCard>>> GetStudentCards();

        [HttpGet("findById")]
        [ProducesResponseType(statusCode: 200, type: typeof(StudentCard))]
        [ProducesResponseType(statusCode: 400, type: typeof(string))]
        public abstract Task<ActionResult<StudentCard>> GetById([FromQuery] int id);

        [HttpGet("findByName")]
        [ProducesResponseType(statusCode: 200, type: typeof(StudentCard))]
        [ProducesResponseType(statusCode: 400, type: typeof(string))]
        public abstract Task<ActionResult<StudentCard>> GetByName([FromQuery] string name);

        [HttpPost("createStudentCard")]
        [ProducesResponseType(statusCode: 201, type: typeof(StudentCard))]
        [ProducesResponseType(statusCode: 400, type: typeof(string))]
        public abstract Task<ActionResult<StudentCard>> CreateStudentCard(CreateRequestStudentCard request);

        [HttpPut("updateStudentCard")]
        [ProducesResponseType(statusCode: 200, type: typeof(StudentCard))]
        [ProducesResponseType(statusCode: 400, type: typeof(string))]
        [ProducesResponseType(statusCode: 404, type: typeof(string))]
        public abstract Task<ActionResult<StudentCard>> UpdateStudentCard([FromQuery] int id, UpdateRequestStudentCard request);

        [HttpDelete("deleteStudentCard")]
        [ProducesResponseType(statusCode: 200, type: typeof(StudentCard))]
        [ProducesResponseType(statusCode: 404, type: typeof(string))]
        public abstract Task<ActionResult<StudentCard>> DeleteStudentCard([FromQuery] int id);


    }
}
