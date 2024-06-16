using OnlineSchool.Courses.Dto;
using OnlineSchool.Courses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Courses.Helpers
{
    public class TestCourseFactory
    {
        public static DtoCourseView CreateCourse(int id)
        {
            return new DtoCourseView
            {
                Id = id,
                Department = "test"+id,
                Name = "test"+id

            };
        }

        public static Course CreateCourseN(int id)
        {
            return new Course
            {
                Id = id,
                Department = "test" + id,
                Name = "test" + id

            };
        }
        
        public static List<DtoCourseView> CreateCourses(int cout)
        {

            List<DtoCourseView> courses = new List<DtoCourseView>();

            for (int i = 0; i < cout; i++)
            {
                courses.Add(CreateCourse(i));
            }

            return courses;
        }
    }
}
