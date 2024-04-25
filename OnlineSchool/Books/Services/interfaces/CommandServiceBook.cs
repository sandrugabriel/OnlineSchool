using OnlineSchool.Books.Dto;
using OnlineSchool.Books.Models;
using OnlineSchool.Books.Repository.interfaces;
using OnlineSchool.System.Constants;
using OnlineSchool.System.Exceptions;

namespace OnlineSchool.Books.Services.interfaces
{
    public class CommandServiceBook : ICommandServiceBook
    {

        private IRepositoryBook _repo;

        public CommandServiceBook(IRepositoryBook repo)
        {
            _repo = repo;
        }

        public async Task<Book> Create(CreateRequestBook createRequest)
        {
            if(createRequest.Name == null)
            {
                throw new InvalidName(Constants.InvalidName);
            }

            var book = await _repo.Create(createRequest);

            return book;
        }

        public async Task<Book> DeleteByIdAsync(int id)
        {
            var book = await _repo.GetByIdAsync(id);
            if (book == null)
            {
                throw new ItemDoesNotExist(Constants.ItemDoesNotExist);
            }

            await _repo.DeleteByIdAsync(id);

            return book;
        }

        public async Task<Book> Update(int id, UpdateRequestBook updateRequest)
        {
            var book = await _repo.GetByIdAsync(id);
            if (book == null)
            {
                throw new ItemDoesNotExist(Constants.ItemDoesNotExist);
            }

            if (book.Name == null)
            {
                throw new InvalidName(Constants.InvalidName);
            }

            book = await _repo.Update(id, updateRequest);

            return book;
        }

    }
}
