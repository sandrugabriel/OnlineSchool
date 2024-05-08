
using OnlineSchool.Enrolments.Dto;
using OnlineSchool.StudentCards.Models;
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

        Task<StudentCard> CardByIdAsync(int id);

        Task<Student> Create(CreateRequestStudent request);

        Task<Student> Update(int id, UpdateRequestStudent request);

        Task<Student> DeleteById(int id);

        Task<Student> CreateBookForStudent(int idStudent, BookCreateDTO createRequestBook);

        Task<Student> UpdateBookForStudent(int idStudent, int idBook, BookUpdateDTO bookUpdateDTO);

        Task<Student> DeleteBookForStudent(int idStudent, int idBook);

        Task<Student> EnrollmentCourse(int idStudent, CreateRequestEnrolment createRequest);

        Task<Student> UnEnrollmentCourse(int idStudent, int idCourse);

    }
}
