using OnlineSchool.Students.Models;

namespace OnlineSchool.Books.Dto
{
    public class UpdateRequestBook
    {
        public int? IdStudent { get; set; }

        public string? Name { get; set; }

        public DateTime? Created_at { get; set; }
    }
}
