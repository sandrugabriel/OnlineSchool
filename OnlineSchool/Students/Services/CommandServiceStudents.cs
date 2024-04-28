using OnlineSchool.Books.Dto;
using OnlineSchool.Books.Repository.interfaces;
using OnlineSchool.Students.Dto;
using OnlineSchool.Students.Models;
using OnlineSchool.Students.Repository.interfaces;
using OnlineSchool.Students.Services.interfaces;
using OnlineSchool.System.Constants;
using OnlineSchool.System.Exceptions;
using System;

namespace OnlineSchool.Students.Services
{
    public class CommandServiceStudents : ICommandServiceStudent
    {
        private IRepositoryStudent _repository;

        public CommandServiceStudents(IRepositoryStudent repository)
        {
            _repository = repository;
        }

        public async Task<Student> CreateBookForStudent(int idStudent,BookCreateDTO createRequestBook)
        {
            var student = await _repository.GetByIdAsync(idStudent);
            if (student == null)
            {
                throw new ItemDoesNotExist(Constants.ItemDoesNotExist);
            }

            if (createRequestBook.Name.Equals(""))
            {
                throw new InvalidName(Constants.InvalidName);
            }

            student = await _repository.CreateBookForStudent(idStudent,createRequestBook);

            return student;
        }

        public async Task<Student> Create(CreateRequestStudent request)
        {

            if (request.Age <= 0)
            {
                throw new InvalidAge(Constants.InvalidAge);
            }
            var student = await _repository.Create(request);

            return student;
        }

        public async Task<Student> Update(int id, UpdateRequestStudent request)
        {

            var student = await _repository.GetByIdAsync(id);
            if (student == null)
            {
                throw new ItemDoesNotExist(Constants.ItemDoesNotExist);
            }


            if (student.Age <= 0)
            {
                throw new InvalidAge(Constants.InvalidAge);
            }
            student = await _repository.Update(id, request);
            return student;
        }

        public async Task<Student> Delete(int id)
        {

            var student = await _repository.GetByIdAsync(id);
            if (student == null)
            {
                throw new ItemDoesNotExist(Constants.ItemDoesNotExist);
            }
            await _repository.DeleteById(id);
            return student;
        }




    }
}
