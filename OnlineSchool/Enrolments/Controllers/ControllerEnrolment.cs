using Microsoft.AspNetCore.Mvc;
using OnlineSchool.Enrolments.Dto;
using OnlineSchool.Enrolments.Models;
using OnlineSchool.Enrolments.Services.interfaces;
using OnlineSchool.Enrolments.Controllers.interfaces;
using OnlineSchool.System.Exceptions;

namespace OnlineSchool.Enrolments.Controllers
{
    public class ControllerEnrolment : ControllerAPIEnrolment
    {
        private IQueryServiceEnrolment _queryService;
        private ICommandServiceEnrolment _commandService;

        public ControllerEnrolment(IQueryServiceEnrolment queryService, ICommandServiceEnrolment commandService)
        {
            _queryService = queryService;
            _commandService = commandService;
        }

        public override async Task<ActionResult<List<Enrolment>>> GetEnrolments()
        {
            try
            {
                var courses = await _queryService.GetAll();

                return Ok(courses);

            }
            catch (ItemsDoNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }

        public override async Task<ActionResult<Enrolment>> GetById([FromQuery] int id)
        {

            try
            {
                var course = await _queryService.GetById(id);
                return Ok(course);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }

        }

        public override async Task<ActionResult<Enrolment>> CreateEnrolment(CreateRequestEnrolment request)
        {
            try
            {
                var course = await _commandService.Create(request);
                return Ok(course);
            }
            catch (InvalidDate ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public override async Task<ActionResult<Enrolment>> UpdateEnrolment([FromQuery] int id, UpdateRequestEnrolment request)
        {
            try
            {
                var course = await _commandService.Update(id, request);
                return Ok(course);
            }
            catch (InvalidDate ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }

        public override async Task<ActionResult<Enrolment>> DeleteEnrolment([FromQuery] int id)
        {
            try
            {
                var course = await _commandService.Delete(id);
                return Ok(course);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
