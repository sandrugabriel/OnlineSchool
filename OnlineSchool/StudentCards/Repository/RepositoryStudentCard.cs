using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineSchool.Data;
using OnlineSchool.StudentCards.Dto;
using OnlineSchool.StudentCards.Models;
using OnlineSchool.StudentCards.Repository.interfaces;

namespace OnlineSchool.StudentCards.Repository
{
    public class RepositoryStudentCard : IRepositoryStudentCard
    {

        private AppDbContext _context;
        private IMapper _mapper;

        public RepositoryStudentCard(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StudentCard> Create(CreateRequestStudentCard createRequest)
        {
            var studentCards = _mapper.Map<StudentCard>(createRequest);
            _context.StudentCards.Add(studentCards);
            await _context.SaveChangesAsync();

            return studentCards;
        }

        public async Task<StudentCard> DeleteByIdAsync(int id)
        {
            var studentCards = await _context.StudentCards.FindAsync(id);

            _context.StudentCards.Remove(studentCards);

            await _context.SaveChangesAsync();

            return studentCards;
        }

        public async Task<List<StudentCard>> GetAllAsync()
        {
            return await _context.StudentCards.ToListAsync();
        }

        public async Task<StudentCard> GetByIdAsync(int id)
        {
            var studentCards = await _context.StudentCards.ToListAsync();

            for (int i = 0; i < studentCards.Count; i++)
            {
                if (studentCards[i].Id == id) return studentCards[i];
            }

            return null;
        }

        public async Task<StudentCard> GetByNameAsync(string name)
        {
            var studentCards = await _context.StudentCards.ToListAsync();

            for (int i = 0; i < studentCards.Count; i++)
            {
                if (studentCards[i].Namecard == name) return studentCards[i];
            }

            return null;
        }

        public async Task<StudentCard> Update(int id, UpdateRequestStudentCard updateRequest)
        {
            var studentCard = await _context.StudentCards.FindAsync(id);

            studentCard.Namecard = updateRequest.Namecard ?? studentCard.Namecard;
            studentCard.IdStudent = updateRequest.IdStudent ?? studentCard.IdStudent;

            _context.StudentCards.Update(studentCard);

            await _context.SaveChangesAsync();

            return studentCard;
        }


    }
}
