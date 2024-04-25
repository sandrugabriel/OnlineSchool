using Microsoft.AspNetCore.Mvc;
using OnlineSchool.Books.Dto;
using OnlineSchool.Books.Models;

namespace OnlineSchool.Books.Controllers.interfaces
{
   /* [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class ControllerAPIBook : ControllerBase
    {

        [HttpGet("/all")]
        [ProducesResponseType(statusCode:200,type: typeof(List<Book>))]
        [ProducesResponseType(statusCode: 400, type: typeof(string))]
        public abstract Task<ActionResult<List<Book>>> GetBooks();


        [HttpGet("/findById")]
        [ProducesResponseType(statusCode: 200, type: typeof(Book))]
        [ProducesResponseType(statusCode: 400, type: typeof(string))]
        public abstract Task<ActionResult<Book>> GetById([FromQuery] int id);

        [HttpGet("/findByName")]
        [ProducesResponseType(statusCode: 200, type: typeof(Book))]
        [ProducesResponseType(statusCode: 400, type: typeof(string))]
        public abstract Task<ActionResult<Book>> GetByName([FromQuery] string name);

        [HttpPost("/createBook")]
        [ProducesResponseType(statusCode: 201, type: typeof(Book))]
        [ProducesResponseType(statusCode: 400, type: typeof(string))]
        public abstract Task<ActionResult<Book>> CreateBook(CreateRequestBook createRequest);


        [HttpPost("/updateBook")]
        [ProducesResponseType(statusCode: 200, type: typeof(Book))]
        [ProducesResponseType(statusCode: 400, type: typeof(string))]
        [ProducesResponseType(statusCode: 404, type: typeof(string))]
        public abstract Task<ActionResult<Book>> UpdateBook([FromQuery]int id, UpdateRequestBook updateRequest);


        [HttpPost("/deleteBook")]
        [ProducesResponseType(statusCode: 201, type: typeof(Book))]
        [ProducesResponseType(statusCode: 404, type: typeof(string))]
        public abstract Task<ActionResult<Book>> DeleteBook([FromQuery]int id);



    }*/
}
