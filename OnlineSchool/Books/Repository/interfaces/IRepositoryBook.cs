using OnlineSchool.Books.Dto;
using OnlineSchool.Books.Models;

namespace OnlineSchool.Books.Repository.interfaces
{
    public interface IRepositoryBook
    {

        Task<List<Book>> GetAllAsync();

        Task<Book> GetByIdAsync(int id);

        Task<Book> GetByNameAsync(string name);

        Task<Book> Create(CreateRequestBook createRequest);

        Task<Book> Update(int id, UpdateRequestBook updateRequest);

        Task<Book> DeleteByIdAsync(int id);

    }
}
