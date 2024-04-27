using OnlineSchool.StudentCards.Dto;
using OnlineSchool.StudentCards.Models;

namespace OnlineSchool.StudentCards.Repository.interfaces
{
    public interface IRepositoryStudentCard
    {
        Task<List<StudentCard>> GetAllAsync();

        Task<StudentCard> GetByIdAsync(int id);

        Task<StudentCard> GetByNameAsync(string name);

        Task<StudentCard> Create(CreateRequestStudentCard createRequest);

        Task<StudentCard> Update(int id, UpdateRequestStudentCard updateRequest);

        Task<StudentCard> DeleteByIdAsync(int id);
    }
}
