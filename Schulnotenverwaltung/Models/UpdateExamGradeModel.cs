namespace Schulnotenverwaltung.Models;

public class UpdateExamGradeModel
{
    public Guid ExamId { get; set; }
    public Guid StudentId { get; set; }
    public double Grade { get; set; }
}