using OnlineSchool.Books.Models;
using OnlineSchool.StudentCards.Models;
using OnlineSchool.Students.Dto;
using OnlineSchool.Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Students.Helpers
{
    public class TestStudentFactory
    {

        public static DtoStudentView CreateStudent(int id)
        {
            return new DtoStudentView
            {
                Id = id,
                Age = id,
                Email = id+"@gmail.com",
                Name = "test"+id

            };
        }

        public static Student CreateStudentN(int id)
        {
            return new Student
            {
                Id = id,
                Age = id,
                Email = id + "@gmail.com",
                Name = "test" + id

            };
        }

        public static StudentCard CreateStudentCard(int id)
        {
            return new StudentCard
            {
                Id = id,
                Namecard = id + "1234",
                IdStudent = id

            };
        }

        public static Book CreateBook(int id, Student student)
        {
            return new Book
            {
                Id = id,
                Created = DateTime.Now,
                IdStudent = id,
                Name = "test"+id,
                Student = student
                
            };
        }

        public static List<DtoStudentView> CreateStudents(int cout) {
        
            List<DtoStudentView> students = new List<DtoStudentView>();

            for(int i=0; i < cout; i++)
            {
                students.Add(CreateStudent(i));
            }

            return students;
        }

    }
}
