using OnlineSchool.Students.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineSchool.Books.Dto
{
    public class CreateRequestBook
    {

        public int IdStudent { get; set; }

        public string Name { get; set; }

        public DateTime Created_at { get; set; }


    }
}
