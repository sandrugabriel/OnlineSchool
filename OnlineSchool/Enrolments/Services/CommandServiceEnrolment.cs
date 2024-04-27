using OnlineSchool.Enrolments.Dto;
using OnlineSchool.Enrolments.Models;
using OnlineSchool.Enrolments.Repository.interfaces;
using OnlineSchool.Enrolments.Services.interfaces;
using OnlineSchool.System.Constants;
using OnlineSchool.System.Exceptions;

namespace OnlineSchool.Enrolments.Services
{
    public class CommandServiceEnrolment : ICommandServiceEnrolment
    {
        private IRepositoryEnrolment _repository;

        public CommandServiceEnrolment(IRepositoryEnrolment repository)
        {
            _repository = repository;
        }

        public async Task<Enrolment> Create(CreateRequestEnrolment request)
        {

            if (request.Created == null)
            {
                throw new InvalidDate(Constants.InvalidDate);
            }
            var course = await _repository.Create(request);

            return course;
        }

        public async Task<Enrolment> Update(int id, UpdateRequestEnrolment request)
        {

            var course = await _repository.GetByIdAsync(id);
            if (course == null)
            {
                throw new ItemDoesNotExist(Constants.ItemDoesNotExist);
            }


            if (course.Created == null)
            {
                throw new InvalidDate(Constants.InvalidDate);
            }
            course = await _repository.Update(id, request);
            return course;
        }

        public async Task<Enrolment> Delete(int id)
        {

            var course = await _repository.GetByIdAsync(id);
            if (course == null)
            {
                throw new ItemDoesNotExist(Constants.ItemDoesNotExist);
            }
            await _repository.DeleteById(id);
            return course;
        }
    }
}
