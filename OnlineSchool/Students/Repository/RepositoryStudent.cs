using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineSchool.Books.Models;
using OnlineSchool.Data;
using OnlineSchool.Enrolments.Dto;
using OnlineSchool.Enrolments.Models;
using OnlineSchool.StudentCards.Models;
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
            return await _context.Students.Include(s=>s.StudentBooks).Include(s => s.CardNumber)
                .Include(s=>s.MyCourses).ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            List<Student> students = await _context.Students.Include(s=>s.StudentBooks).Include(s => s.CardNumber)
                .Include(s => s.MyCourses).ToListAsync();

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Id == id) return students[i];
            }
            return null;
        }

        public async Task<StudentCard> CardByIdAsync(int id)
        {
            List<Student> students = await _context.Students.Include(s => s.StudentBooks).Include(s=>s.CardNumber)
                .Include(s => s.MyCourses).ToListAsync();
            var student = (Student)null;
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Id == id) student = students[i];
            }

            if (student != null) return student.CardNumber; 
            return null;
        }

        public async Task<Student> GetByNameAsync(string name)
        {
            List<Student> allStudents = await _context.Students.Include(s => s.StudentBooks).Include(s => s.CardNumber)
                .Include(s => s.MyCourses).ToListAsync();

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
            var card = _mapper.Map<StudentCard>(request);
            card.IdStudent = student.Id;
            var ran = new Random();

            card.Namecard = student.Name + ran.Next(0,100000);
            _context.Studentscard.Add(card);
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

        public async Task<Student> CreateBookForStudent(int idStudent, BookCreateDTO createRequestBook)
        {
            var student = await _context.Students.FindAsync(idStudent);


            Book book = _mapper.Map<Book>(createRequestBook);

            if (student.StudentBooks == null)
                _context.Entry(student).Collection(s => s.StudentBooks).Load();

            if (student.StudentBooks == null)
               student.StudentBooks = new List<Book>();


            student.StudentBooks.Add(book);
          //  _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return student;

        }

        public async Task<Student> UpdateBookForStudent(int idStudent,int idBook, BookUpdateDTO bookUpdateDTO)
        {
            var student = await _context.Students.FindAsync(idStudent);

            var books = student.StudentBooks;
            var book = (Book)null;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Id == idBook)
                {
                    book = books[i];
                    break;
                }
            }

            book.Name = bookUpdateDTO.Name ?? book.Name;
            book.Created = bookUpdateDTO.Created_at ?? book.Created;

            _context.Update(book);

            if (student.StudentBooks == null)
                _context.Entry(student).Collection(s => s.StudentBooks).Load();

            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<Student> DeleteBookForStudent(int idStudent, int idBook)
        {
            var student = await _context.Students.FindAsync(idStudent);

            var books = student.StudentBooks;
            var book = (Book)null;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Id == idBook)
                {
                    book = books[i];
                    break;
                }
            }

            _context.Books.Remove(book);
            

            if (student.StudentBooks == null)
                _context.Entry(student).Collection(s => s.StudentBooks).Load();

          //  student.StudentBooks.Remove(book);

            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<Student> EnrollmentCourse(int idStudent, CreateRequestEnrolment requestEnrolment)
        {
            var student = await _context.Students.FindAsync(idStudent);


            Enrolment enrolment = _mapper.Map<Enrolment>(requestEnrolment);

            enrolment.IdStudent = idStudent;
            if (student.MyCourses == null)
                _context.Entry(student).Collection(s => s.MyCourses).Load();

            if (student.MyCourses == null)
                student.MyCourses = new List<Enrolment>();

            if (student.MyCourses.Find(n => n.IdCourse == enrolment.IdCourse) != null)
                return null;

            _context.Enrolments.Add(enrolment);
           // student.MyCourses.Add(enrolment);

            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UnEnrollmentCourse(int idStudent, int idCourse)
        {
            var student = await _context.Students.FindAsync(idStudent);

            var entrolment = await _context.Enrolments.FirstOrDefaultAsync(n => n.IdCourse == idCourse && n.IdStudent == idStudent);

            _context.Enrolments.Remove(entrolment);
            // student.MyCourses.Add(enrolment);

            await _context.SaveChangesAsync();
            return student;
        }
    }
}
