using Microsoft.EntityFrameworkCore;

namespace Schulnotenverwaltung.Data;

public class GradesDbContext : DbContext
{
    public GradesDbContext() {}
    
    public GradesDbContext(DbContextOptions<GradesDbContext> options) : base(options)
    {
    }
    
    public DbSet<Class> Classes { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<ExamGrade> ExamGrades { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exam>()
            .HasOne(e => e.Class)
            .WithMany(e => e.Exams)
            .HasForeignKey(e => e.ClassId)
            .OnDelete(DeleteBehavior.ClientNoAction);
        
        modelBuilder.Entity<ExamGrade>()
            .HasOne(e => e.Exam)
            .WithMany(e => e.ExamGrades)
            .HasForeignKey(e => e.ExamId)
            .OnDelete(DeleteBehavior.ClientNoAction);
        
        modelBuilder.Entity<ExamGrade>()
            .HasOne(e => e.Student)
            .WithMany(e => e.ExamGrades)
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.ClientNoAction);
        
        modelBuilder.Entity<Student>()
            .HasOne(e => e.Class)
            .WithMany(e => e.Students)
            .HasForeignKey(e => e.ClassId)
            .OnDelete(DeleteBehavior.ClientNoAction);

        modelBuilder.Entity<Class>()
            .HasIndex(u => u.Name)
            .IsUnique();
    }
}