using Microsoft.AspNetCore.Mvc;
using OnlineSchool.Books.Models;
using OnlineSchool.Books.Services.interfaces;
using OnlineSchool.Enrolments.Dto;
using OnlineSchool.StudentCards.Models;
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

        public ControllerStudent(IQueryServiceStudent queryService, ICommandServiceStudent commandService) 
        {
            _queryService = queryService;
            _commandService = commandService;
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

        public override async Task<ActionResult<StudentCard>> GetStudentCard([FromQuery] int id)
        {

            try
            {
                var student = await _queryService.CardById(id);
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

        public override async Task<ActionResult<Student>> CreateBookForStudent([FromQuery] int idStudent, BookCreateDTO request)
        {
            try
            {
                var student = await _commandService.CreateBookForStudent(idStudent, request);

                return Ok(student);

            }catch(ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
            catch(InvalidName ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public override async Task<ActionResult<Student>> UpdateBookForStudent([FromQuery] int idStudent, [FromQuery] int idBook, BookUpdateDTO request)
        {
            try
            {
                var student = await _commandService.UpdateBookForStudent(idStudent,idBook, request);

                return Ok(student);

            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidName ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public override async Task<ActionResult<Student>> DeleteBookForStudent([FromQuery] int idStudent, [FromQuery] int idBook)
        {
            try
            {
                var student = await _commandService.DeleteBookForStudent(idStudent, idBook);

                return Ok(student);

            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }

        public override async Task<ActionResult<Student>> EnrollmentCourse([FromQuery] int idStudent, CreateRequestEnrolment request)
        {

            try
            {
                var student = await _commandService.EnrollmentCourse(idStudent, request);

                return Ok(student);

            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidCourse ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public override async Task<ActionResult<Student>> UnEnrollmentCourse([FromQuery] int idStudent, [FromQuery] int idCourse)
        {
            try
            {
                var student = await _commandService.UnEnrollmentCourse(idStudent, idCourse);

                return Ok(student);

            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
