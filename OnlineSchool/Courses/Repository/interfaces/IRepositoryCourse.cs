

using OnlineSchool.Courses.Dto;
using OnlineSchool.Courses.Models;

namespace OnlineSchool.Courses.Repository.interfaces
{
    public interface IRepositoryCourse
    {
        Task<List<Course>> GetAllAsync();
        Task<Course> GetByNameAsync(string destination);

        Task<Course> GetByIdAsync(int id);


        Task<Course> Create(CreateRequestCourse request);

        Task<Course> Update(int id, UpdateRequestCourse request);

        Task<Course> DeleteById(int id);

    }
}
