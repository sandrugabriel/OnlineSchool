using System.ComponentModel.DataAnnotations;

namespace OnlineSchool.Enrolments.Dto
{
    public class CreateRequestEnrolment
    {
        public int Id { get; set; }

        public int IdCourse { get; set; }

        public int IdStudent { get; set; }

        public DateTime Created { get; set; }
    }
}
