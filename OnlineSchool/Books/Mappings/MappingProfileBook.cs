using AutoMapper;
using OnlineSchool.Books.Dto;
using OnlineSchool.Books.Models;

namespace OnlineSchool.Books.Mappings
{
    public class MappingProfileBook : Profile
    {

        public MappingProfileBook()
        {
            CreateMap<CreateRequestBook, Book>();
        }
    }
}
