using OnlineSchool.StudentCards.Dto;
using OnlineSchool.StudentCards.Models;
using OnlineSchool.StudentCards.Repository.interfaces;
using OnlineSchool.StudentCards.Services.interfaces;
using OnlineSchool.System.Constants;
using OnlineSchool.System.Exceptions;

namespace OnlineSchool.StudentCardCards.Services
{
    public class CommandServiceStudentCard : ICommandServiceStudentCard
    {
        private IRepositoryStudentCard _repository;

        public CommandServiceStudentCard(IRepositoryStudentCard repository)
        {
            _repository = repository;
        }

        public async Task<StudentCard> Create(CreateRequestStudentCard request)
        {

            if (request.Card_number.Length <= 0)
            {
                throw new InvalidCardNume(Constants.InvalidCardName);
            }
            var student = await _repository.Create(request);

            return student;
        }

        public async Task<StudentCard> Update(int id, UpdateRequestStudentCard request)
        {

            var student = await _repository.GetByIdAsync(id);
            if (student == null)
            {
                throw new ItemDoesNotExist(Constants.ItemDoesNotExist);
            }


            if (student.Namecard.Length <= 0)
            {
                throw new InvalidCardNume(Constants.InvalidCardName);
            }
            student = await _repository.Update(id, request);
            return student;
        }

        public async Task<StudentCard> Delete(int id)
        {

            var student = await _repository.GetByIdAsync(id);
            if (student == null)
            {
                throw new ItemDoesNotExist(Constants.ItemDoesNotExist);
            }
            await _repository.DeleteByIdAsync(id);
            return student;
        }
    }
}
