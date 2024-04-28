using AutoMapper;
using OnlineSchool.Books.Dto;
using OnlineSchool.Books.Models;
using OnlineSchool.Students.Dto;

namespace OnlineSchool.Books.Mappings
{
    public class MappingProfileBook : Profile
    {

        public MappingProfileBook()
        {
            CreateMap<CreateRequestBook, Book>();

            CreateMap<BookCreateDTO, Book>();
        }
    }
}
