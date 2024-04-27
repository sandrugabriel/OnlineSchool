using OnlineSchool.Enrolments.Dto;
using OnlineSchool.Enrolments.Models;

namespace OnlineSchool.Enrolments.Repository.interfaces
{
    public interface IRepositoryEnrolment
    {

        Task<List<Enrolment>> GetAllAsync();
        Task<Enrolment> GetByIdAsync(int id);


        Task<Enrolment> Create(CreateRequestEnrolment request);

        Task<Enrolment> Update(int id, UpdateRequestEnrolment request);

        Task<Enrolment> DeleteById(int id);
    }
}
