using Microsoft.AspNetCore.Mvc;
using OnlineSchool.StudentCards.Controllers.interfaces;
using OnlineSchool.StudentCards.Dto;
using OnlineSchool.StudentCards.Models;
using OnlineSchool.StudentCards.Services.interfaces;
using OnlineSchool.System.Exceptions;

namespace OnlineSchool.StudentCardCards.Controllers
{
    public class ControllerStudentCard : ControllerAPIStudentCard
    {
        private IQueryServiceStudentCard _queryService;
        private ICommandServiceStudentCard _commandService;

        public ControllerStudentCard(IQueryServiceStudentCard queryService, ICommandServiceStudentCard commandService)
        {
            _queryService = queryService;
            _commandService = commandService;
        }

        public override async Task<ActionResult<List<StudentCard>>> GetStudentCards()
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

        public override async Task<ActionResult<StudentCard>> GetByName([FromQuery] string name)
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

        public override async Task<ActionResult<StudentCard>> GetById([FromQuery] int id)
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

        public override async Task<ActionResult<StudentCard>> CreateStudentCard(CreateRequestStudentCard request)
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

        public override async Task<ActionResult<StudentCard>> UpdateStudentCard([FromQuery] int id, UpdateRequestStudentCard request)
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

        public override async Task<ActionResult<StudentCard>> DeleteStudentCard([FromQuery] int id)
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

    }
}
