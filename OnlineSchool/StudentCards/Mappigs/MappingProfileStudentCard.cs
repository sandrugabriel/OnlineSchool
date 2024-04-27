using AutoMapper;
using OnlineSchool.StudentCards.Dto;
using OnlineSchool.StudentCards.Models;

namespace OnlineSchool.StudentCards.Mappigs
{
    public class MappingProfileStudentCard : Profile
    {
            public MappingProfileStudentCard()
            {
                CreateMap<CreateRequestStudentCard, StudentCard>();
            }
        
    }
}
