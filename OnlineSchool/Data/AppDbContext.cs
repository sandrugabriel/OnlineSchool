
using Microsoft.EntityFrameworkCore;
using OnlineSchool.Books.Models;
using OnlineSchool.Students.Models;


namespace OnlineSchool.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(studentBook => studentBook.Student)
                .WithMany(student => student.studentBooks)
                .HasForeignKey(studentBook => studentBook.IdStudent);
        

        }

    }
}
