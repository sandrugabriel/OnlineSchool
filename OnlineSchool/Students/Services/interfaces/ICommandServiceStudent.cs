using OnlineSchool.Books.Dto;
using OnlineSchool.Students.Dto;
using OnlineSchool.Students.Models;
using System;

namespace OnlineSchool.Students.Services.interfaces
{
    public interface ICommandServiceStudent
    {
        Task<Student> Create(CreateRequestStudent request);

        Task<Student> Update(int id, UpdateRequestStudent request);

        Task<Student> Delete(int id);

        Task<Student> CreateBookForStudent(int idStudent, BookCreateDTO createRequestBook);
    }
}
