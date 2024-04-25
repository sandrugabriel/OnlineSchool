using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineSchool.Books.Dto;
using OnlineSchool.Books.Models;
using OnlineSchool.Books.Repository.interfaces;
using OnlineSchool.Data;

namespace OnlineSchool.Books.Repository
{
    public class RepositoryBook : IRepositoryBook
    {

        private AppDbContext _context;
        private IMapper _mapper;

        public RepositoryBook(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Book> Create(CreateRequestBook createRequest)
        {
           var books = _mapper.Map<Book>(createRequest);
            _context.Books.Add(books);
            await _context.SaveChangesAsync();

            return books;
        }

        public async Task<Book> DeleteByIdAsync(int id)
        {
            var books = await _context.Books.FindAsync(id);

            _context.Books.Remove(books);

            await _context.SaveChangesAsync();

            return books;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var books = await _context.Books.ToListAsync();

            for(int i=0;i<books.Count; i++)
            {
                if (books[i].Id == id) return books[i];
            }

            return null;
        }

        public async Task<Book> GetByNameAsync(string name)
        {
            var books = await _context.Books.ToListAsync();

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Name == name) return books[i];
            }

            return null;
        }

        public async Task<Book> Update(int id, UpdateRequestBook updateRequest)
        {
            var book = await _context.Books.FindAsync(id);

            book.Name = updateRequest.Name ?? book.Name;
            book.Created_at = updateRequest.Created_at ?? book.Created_at;
            book.IdStudent = updateRequest.IdStudent ?? book.IdStudent;

            _context.Books.Update(book);

            await _context.SaveChangesAsync();

            return book;
        }
    }
}
