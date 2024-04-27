using Microsoft.AspNetCore.Mvc;
using OnlineSchool.Books.Controllers.interfaces;
using OnlineSchool.Books.Dto;
using OnlineSchool.Books.Models;
using OnlineSchool.Books.Services.interfaces;
using OnlineSchool.System.Exceptions;

namespace OnlineSchool.Books.Controllers
{
    public class ControllerBook : ControllerAPIBook
    {

        private IQueryServiceBook _query;
        private ICommandServiceBook _command;

        public ControllerBook(IQueryServiceBook query, ICommandServiceBook command)
        {
            _query = query;
            _command = command;
        }


        public override async Task<ActionResult<List<Book>>> GetBooks()
        {
            try
            {
                var book = await _query.GetAllAsync();

                return Ok(book);
            }
            catch (ItemsDoNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }
        public override async Task<ActionResult<Book>> GetById([FromQuery] int id)
        {
            try
            {
                var book = await _query.GetByIdAsync(id);

                return Ok(book);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }

        public override async Task<ActionResult<Book>> GetByName([FromQuery] string name)
        {
            try
            {
                var book = await _query.GetByNameAsync(name);

                return Ok(book);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }

        public override async Task<ActionResult<Book>> CreateBook(CreateRequestBook createRequest)
        {
            try
            {
                var book = await _command.Create(createRequest);

                return Ok(book);
            }
            catch (InvalidName ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public override async Task<ActionResult<Book>> UpdateBook([FromQuery] int id, UpdateRequestBook updateRequest)
        {
            try
            {
                var book = await _command.Update(id, updateRequest);

                return Ok(book);
            }
            catch (InvalidName ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }

        public override async Task<ActionResult<Book>> DeleteBook([FromQuery] int id)
        {
            try
            {
                var book = await _command.DeleteByIdAsync(id);

                return Ok(book);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }


        }




    }
}
