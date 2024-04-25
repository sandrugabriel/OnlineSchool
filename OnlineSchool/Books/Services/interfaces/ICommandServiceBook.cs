using OnlineSchool.Books.Dto;
using OnlineSchool.Books.Models;

namespace OnlineSchool.Books.Services.interfaces
{
    public interface ICommandServiceBook
    {
        Task<Book> Create(CreateRequestBook createRequest);

        Task<Book> Update(int id, UpdateRequestBook updateRequest);

        Task<Book> DeleteByIdAsync(int id);

    }
}
