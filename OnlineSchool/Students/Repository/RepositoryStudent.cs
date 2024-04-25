using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineSchool.Data;
using OnlineSchool.Students.Dto;
using OnlineSchool.Students.Models;
using OnlineSchool.Students.Repository.interfaces;
using System;

namespace OnlineSchool.Students.Repository
{
    public class RepositoryStudent : IRepositoryStudent
    {

        private AppDbContext _context;
        private IMapper _mapper;

        public RepositoryStudent(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            List<Student> students = await _context.Students.ToListAsync();

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Id == id) return students[i];
            }
            return null;
        }

        public async Task<Student> GetByNameAsync(string name)
        {
            List<Student> allStudents = await _context.Students.ToListAsync();

            for (int i = 0; i < allStudents.Count; i++)
            {
                if (allStudents[i].Name.Equals(name))
                {
                    return allStudents[i];
                }
            }
            return null;
        }


        public async Task<Student> Create(CreateRequestStudent request)
        {

            var student = _mapper.Map<Student>(request);

            _context.Students.Add(student);

            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> Update(int id, UpdateRequestStudent request)
        {

            var student = await _context.Students.FindAsync(id);

            student.Age = request.Age ?? student.Age;
            student.Email = request.Email ?? student.Email;
            student.Name = request.Name ?? student.Name;

            _context.Students.Update(student);

            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<Student> DeleteById(int id)
        {
            var student = await _context.Students.FindAsync(id);

            _context.Students.Remove(student);

            await _context.SaveChangesAsync();

            return student;
        }

    }
}
