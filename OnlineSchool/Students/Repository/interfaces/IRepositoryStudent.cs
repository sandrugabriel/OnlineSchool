using OnlineSchool.Students.Dto;
using OnlineSchool.Students.Models;
using System;

namespace OnlineSchool.Students.Repository.interfaces
{
    public interface IRepositoryStudent
    {

        Task<List<Student>> GetAllAsync();
        Task<Student> GetByNameAsync(string destination);

        Task<Student> GetByIdAsync(int id);


        Task<Student> Create(CreateRequestStudent request);

        Task<Student> Update(int id, UpdateRequestStudent request);

        Task<Student> DeleteById(int id);


    }
}
