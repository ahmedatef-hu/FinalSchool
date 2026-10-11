using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

namespace SchoolManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentProfile> StudentProfiles { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Teacher>()
                .HasMany(d => d.Courses)
                .WithOne(d => d.Teacher)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Enrollment>()
                .HasOne(t => t.Student)
                .WithMany(e => e.Enrollments)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Enrollment>()
                .HasOne(t => t.Course)
                .WithMany(e => e.Enrollments)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
                .HasOne(d => d.Profile)
                .WithOne(d => d.Student)
                .HasForeignKey<StudentProfile>(s => s.StudentId);

        }
    }
}
