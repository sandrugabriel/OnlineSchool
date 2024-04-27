using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineSchool.Books.Models;
using OnlineSchool.Enrolments.Models;
using OnlineSchool.StudentCards.Models;

namespace OnlineSchool.Students.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int Age { get; set; }

     /*   public string description()
        {
            string t = "";
            t += "Id: " + Id + "\n";
            t += "Name: " + Name + "\n";
            t += "Email: " + Email + "\n";
            t += "Age: " + Age + "\n";

            return t;
        }*/

        public virtual StudentCard StudentCard { get; set; }
        public virtual List<Book> StudentBooks { get; set; }
        public virtual List<Enrolment> Enrolments { get; set; }


    }
}
