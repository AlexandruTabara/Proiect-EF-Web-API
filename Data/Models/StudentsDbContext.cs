using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class StudentsDbContext : DbContext, IStudentsDbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Course> Courses { get; set; }
        public StudentsDbContext(DbContextOptions<StudentsDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
