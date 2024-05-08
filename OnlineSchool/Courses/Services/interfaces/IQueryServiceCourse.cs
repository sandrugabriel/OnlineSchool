

using OnlineSchool.Courses.Models;

namespace OnlineSchool.Courses.Services.interfaces
{
    public interface IQueryServiceCourse
    {

        Task<List<Course>> GetAll();

        Task<Course> GetById(int id);

        Task<Course> GetByNameAsync(string name);
    }
}
