
using OnlineSchool.StudentCards.Dto;
using OnlineSchool.StudentCards.Models;

namespace OnlineSchool.StudentCards.Services.interfaces
{
    public interface ICommandServiceStudentCard
    {
        Task<StudentCard> Create(CreateRequestStudentCard request);

        Task<StudentCard> Update(int id, UpdateRequestStudentCard request);

        Task<StudentCard> Delete(int id);
    }
}
