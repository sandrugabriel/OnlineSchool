using OnlineSchool.StudentCards.Models;
using OnlineSchool.Students.Models;
using System;

namespace OnlineSchool.Students.Services.interfaces
{
    public interface IQueryServiceStudent
    {

        Task<List<Student>> GetAll();

        Task<Student> GetById(int id);

        Task<Student> GetByNameAsync(string name);

        Task<StudentCard> CardById(int id);
    }
}
