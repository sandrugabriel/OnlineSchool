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

        public ControllerEnrolment(IQueryServiceEnrolment queryService)
        {
            _queryService = queryService;
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

    }
}
