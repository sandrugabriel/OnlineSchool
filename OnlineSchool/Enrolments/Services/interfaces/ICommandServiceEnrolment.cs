

using OnlineSchool.Enrolments.Dto;
using OnlineSchool.Enrolments.Models;

namespace OnlineSchool.Enrolments.Services.interfaces
{
    public interface ICommandServiceEnrolment
    {
        Task<Enrolment> Create(CreateRequestEnrolment request);

        Task<Enrolment> Update(int id, UpdateRequestEnrolment request);

        Task<Enrolment> Delete(int id);
    }
}
