namespace Schulnotenverwaltung.Models;

public class ExamGradeModel
{
    public Guid? Id { get; set; }
    public Guid? ExamId { get; set; }
    public double? Grade { get; set; }
}