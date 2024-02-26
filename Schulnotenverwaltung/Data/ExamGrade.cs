namespace Schulnotenverwaltung.Data;

public class ExamGrade
{
    public Guid Id { get; set; }
    public Exam Exam { get; set; }
    public Guid ExamId { get; set; }
    public Student Student { get; set; }
    public Guid StudentId { get; set; }
    public double Grade { get; set; }
}