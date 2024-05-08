using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineSchool.Courses.Dto;
using OnlineSchool.Courses.Models;
using OnlineSchool.Courses.Repository.interfaces;
using OnlineSchool.Data;

namespace OnlineSchool.Courses.Repository
{
    public class RepositoryCourse : IRepositoryCourse
    {


        private AppDbContext _context;
        private IMapper _mapper;

        public RepositoryCourse(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await _context.Courses.Include(s => s.EnrolledStudents).ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            List<Course> courses = await _context.Courses.Include(s => s.EnrolledStudents).ToListAsync();

            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].Id == id) return courses[i];
            }
            return null;
        }

        public async Task<Course> GetByNameAsync(string name)
        {
            List<Course> allCourses = await _context.Courses.Include(s => s.EnrolledStudents).ToListAsync();

            for (int i = 0; i < allCourses.Count; i++)
            {
                if (allCourses[i].Name.Equals(name))
                {
                    return allCourses[i];
                }
            }
            return null;
        }


        public async Task<Course> Create(CreateRequestCourse request)
        {

            var course = _mapper.Map<Course>(request);

            _context.Courses.Add(course);

            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<Course> Update(int id, UpdateRequestCourse request)
        {

            var course = await _context.Courses.FindAsync(id);

            course.Name = request.Name ?? course.Name;
            course.Department = request.Department ?? course.Department;

            _context.Courses.Update(course);

            await _context.SaveChangesAsync();

            return course;
        }

        public async Task<Course> DeleteById(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            _context.Courses.Remove(course);

            await _context.SaveChangesAsync();

            return course;
        }


    }
}
