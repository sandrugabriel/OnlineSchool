using Microsoft.AspNetCore.Mvc;
using OnlineSchool.Books.Dto;
using OnlineSchool.Books.Models;
using OnlineSchool.Books.Services.interfaces;
using OnlineSchool.Students.Controllers.interfaces;
using OnlineSchool.Students.Dto;
using OnlineSchool.Students.Models;
using OnlineSchool.Students.Services.interfaces;
using OnlineSchool.System.Exceptions;
using System;

namespace OnlineSchool.Students.Controllers
{
    public class ControllerStudent : ControllerAPIStudent
    {
        private IQueryServiceStudent _queryService;
        private ICommandServiceStudent _commandService;
        private ICommandServiceBook _commandBook;

        public ControllerStudent(IQueryServiceStudent queryService, ICommandServiceStudent commandService,ICommandServiceBook commandServiceBook) 
        {
            _queryService = queryService;
            _commandService = commandService;
            _commandBook = commandServiceBook;
        }

        public override async Task<ActionResult<List<Student>>> GetStudents()
        {
            try
            {
                var students = await _queryService.GetAll();

                return Ok(students);

            }
            catch (ItemsDoNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }

        public override async Task<ActionResult<Student>> GetByName([FromQuery] string name)
        {

            try
            {
                var student = await _queryService.GetByNameAsync(name);
                return Ok(student);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }

        }

        public override async Task<ActionResult<Student>> GetById([FromQuery] int id)
        {

            try
            {
                var student = await _queryService.GetById(id);
                return Ok(student);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }

        }

        public override async Task<ActionResult<Student>> CreateStudent(CreateRequestStudent request)
        {
            try
            {
                var student = await _commandService.Create(request);
                return Ok(student);
            }
            catch (InvalidAge ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public override async Task<ActionResult<Student>> UpdateStudent([FromQuery] int id, UpdateRequestStudent request)
        {
            try
            {
                var student = await _commandService.Update(id, request);
                return Ok(student);
            }
            catch (InvalidAge ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }

        public override async Task<ActionResult<Student>> DeleteStudent([FromQuery] int id)
        {
            try
            {
                var student = await _commandService.Delete(id);
                return Ok(student);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }

        public override async Task<ActionResult<Book>> CreateBook(CreateRequestBook request)
        {
            try
            {
                var student = await _commandBook.Create(request);
                return Ok(student);
            }
            catch (InvalidAge ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
