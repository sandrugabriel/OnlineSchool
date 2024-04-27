
using Microsoft.EntityFrameworkCore;
using OnlineSchool.Books.Models;
using OnlineSchool.Courses.Models;
using OnlineSchool.Enrolments.Models;
using OnlineSchool.StudentCards.Models;
using OnlineSchool.Students.Models;


namespace OnlineSchool.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Enrolment> Enrolments { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<StudentCard> StudentCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCard>()
                .HasOne(studentcard => studentcard.Student)
                .WithOne(student=>student.StudentCard)
                .HasForeignKey<StudentCard>(sc => sc.IdStudent);

            modelBuilder.Entity<Book>()
                .HasOne(studentBook => studentBook.Student)
                .WithMany(student => student.StudentBooks)
                .HasForeignKey(studentBook => studentBook.IdStudent);


            modelBuilder.Entity<Enrolment>()
              .HasOne(student => student.Student)
              .WithMany(en => en.Enrolments)
              .HasForeignKey(student => student.IdStudent);

            modelBuilder.Entity<Enrolment>()
             .HasOne(course => course.Course)
             .WithMany(en => en.Enrolments)
             .HasForeignKey(course => course.IdCourse);

        }

    }
}
