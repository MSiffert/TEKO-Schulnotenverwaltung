namespace Schulnotenverwaltung.Data;

public class Exam
{
    public Exam()
    {
        ExamGrades = new List<ExamGrade>();
    }
    
    public Guid Id { get; set; }
    public Class Class { get; set; }
    public Guid ClassId { get; set; }
    public string Description { get; set; }
    
    public ICollection<ExamGrade> ExamGrades { get; set; }
}