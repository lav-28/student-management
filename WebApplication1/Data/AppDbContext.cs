using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🎓 Student Config
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.StudentId);

                entity.Property(s => s.FirstName)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(s => s.LastName)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(s => s.Email)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.HasIndex(s => s.Email)
                      .IsUnique();
            });

            // 📘 Course Config
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(c => c.CourseId);

                entity.Property(c => c.CourseName)
                      .IsRequired()
                      .HasMaxLength(100);
            });

            // 🧾 Enrollment Config (CORE RELATIONSHIP)
            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(e => e.EnrollmentId);

                // Student → Enrollment (1 to many)
                entity.HasOne(e => e.Student)
                      .WithMany(s => s.Enrollments)
                      .HasForeignKey(e => e.StudentId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Course → Enrollment (1 to many)
                entity.HasOne(e => e.Course)
                      .WithMany(c => c.Enrollments)
                      .HasForeignKey(e => e.CourseId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Prevent duplicate enrollment
                entity.HasIndex(e => new { e.StudentId, e.CourseId })
                      .IsUnique();
            });
        }
    }
}
